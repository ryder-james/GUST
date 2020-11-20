using UnityEditor;
using UnityEngine;

using GUST.Spells;
using GUST.Characters;

[CustomEditor(typeof(Spell))]
public class SpellEditor : Editor {
	// Basic string info //
	private new SerializedProperty name;
	private SerializedProperty description;
	private SerializedProperty techLevel;
	private SerializedProperty powerSource;
	private SerializedProperty spellClass;
	private SerializedProperty pageRef;
	private SerializedProperty notes;

	// Attribute //
	private SerializedProperty isResisted;
	private SerializedProperty resistedBy;

	// Needs editors //
	private SerializedProperty spellSkill;
	private SerializedProperty spellCost;
	private SerializedProperty maintenanceCost;
	private SerializedProperty castingTime;
	private SerializedProperty duration;
	private SerializedProperty enchantmentInfo;

	private Editor spellSkillEditor, spellCostEditor, maintenanceCostEditor, 
		castingTimeEditor, durationEditor, enchantmentInfoEditor;

	// Lists //
	private SerializedProperty colleges;
	private SerializedProperty prereqs;

	private Spell spell;

	private void OnEnable() {
		name = serializedObject.FindProperty("name");
		description = serializedObject.FindProperty("description");
		techLevel = serializedObject.FindProperty("techLevel");
		powerSource = serializedObject.FindProperty("powerSource");
		spellClass = serializedObject.FindProperty("spellClass");
		pageRef = serializedObject.FindProperty("pageRef");
		notes = serializedObject.FindProperty("notes");
		isResisted = serializedObject.FindProperty("isResisted");
		resistedBy = serializedObject.FindProperty("resistedBy");
		spellSkill = serializedObject.FindProperty("spellSkill");
		spellCost = serializedObject.FindProperty("spellCost");
		maintenanceCost = serializedObject.FindProperty("maintenanceCost");
		castingTime = serializedObject.FindProperty("castingTime");
		duration = serializedObject.FindProperty("duration");
		enchantmentInfo = serializedObject.FindProperty("enchantmentInfo");
		colleges = serializedObject.FindProperty("colleges");
		prereqs = serializedObject.FindProperty("prereqs");

		spell = (Spell) target;
	}

	public override void OnInspectorGUI() {
		serializedObject.Update();

		EditorGUILayout.PropertyField(name);

		EditorGUILayout.LabelField("Description");
		EditorStyles.textArea.wordWrap = true;
		spell.Description = EditorGUILayout.TextArea(spell.Description, EditorStyles.textArea);

		EditorGUILayout.PropertyField(techLevel);
		EditorGUILayout.PropertyField(powerSource);
		EditorGUILayout.PropertyField(spellClass);
		EditorGUILayout.PropertyField(pageRef);
		EditorGUILayout.PropertyField(notes);

		EditorGUILayout.PropertyField(isResisted);
		if (isResisted.boolValue) {
			EditorGUILayout.PropertyField(resistedBy);
		}

		spell.SpellSkill = DrawSettingsEditor(spell.SpellSkill, ref spellSkillEditor, ref spellSkill, out bool remove);
		if (remove) {
			DestroyImmediate(spell.SpellSkill);
			spell.SpellSkill = null;
		}

		spell.SpellCost = DrawSettingsEditor(spell.SpellCost, ref spellCostEditor, ref spellCost, out remove);
		if (remove) {
			DestroyImmediate(spell.SpellCost);
			spell.SpellCost = null;
		}

		spell.MaintenanceCost = DrawSettingsEditor(spell.MaintenanceCost, ref maintenanceCostEditor, ref maintenanceCost, out remove);
		if (remove) {
			DestroyImmediate(spell.MaintenanceCost);
			spell.MaintenanceCost = null;
		}

		spell.CastingTime = DrawSettingsEditor(spell.CastingTime, ref castingTimeEditor, ref castingTime, out remove);
		if (remove) {
			DestroyImmediate(spell.CastingTime);
			spell.CastingTime = null;				
		}

		spell.Duration = DrawSettingsEditor(spell.Duration, ref durationEditor, ref duration, out remove);
		if (remove) {
			DestroyImmediate(spell.Duration);
			spell.Duration = null;
		}

		spell.EnchantmentInfo = DrawSettingsEditor(spell.EnchantmentInfo, ref enchantmentInfoEditor, ref enchantmentInfo, out remove);
		if (remove) {
			DestroyImmediate(spell.EnchantmentInfo);
			spell.EnchantmentInfo = null;
		}

		EditorGUILayout.PropertyField(colleges);
		EditorGUILayout.PropertyField(prereqs);

		serializedObject.ApplyModifiedProperties();
	}

	private T DrawSettingsEditor<T>(T toDraw, ref Editor editor, ref SerializedProperty settings, out bool remove) where T : ScriptableObject {
		remove = false;
		if (toDraw != null) {
			GUILayout.BeginHorizontal();
			settings.isExpanded = EditorGUILayout.InspectorTitlebar(settings.isExpanded, toDraw);
			remove = GUILayout.Button("Remove");
			GUILayout.EndHorizontal();

			if (settings.isExpanded) {
				EditorGUILayout.PrefixLabel(settings.displayName);
				EditorGUI.indentLevel++;
				using (EditorGUI.ChangeCheckScope check = new EditorGUI.ChangeCheckScope()) {
					CreateCachedEditor(toDraw, null, ref editor);
					editor.OnInspectorGUI();
				}
				EditorGUI.indentLevel--;
			}

			return toDraw;
		} else {
			T t = null;
			GUILayout.BeginHorizontal();
			EditorGUILayout.PropertyField(settings);
			if (GUILayout.Button("Create")) {
				t = Create(toDraw);
			}
			GUILayout.EndHorizontal();
			return t;
		}
	}

	private T Create<T>(T _) where T : ScriptableObject {
		return (T) CreateInstance(typeof(T));
	}
}
