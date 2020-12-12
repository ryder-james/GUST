using GUST.Spells;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddSpellBtn : MonoBehaviour
{
    [SerializeField] GameObject spellUIPrefab;
    [SerializeField] RectTransform WhereGo;

    [SerializeField] GameObject lePopup;
    [SerializeField] GameObject header;
    [SerializeField] GameObject body;
    [SerializeField] GameObject HeaderBackground;
    [SerializeField] TMP_InputField Title;
    [SerializeField] TMP_InputField Colleges;
    [SerializeField] TMP_InputField PageRef;
    [SerializeField] TMP_InputField Type;
    [SerializeField] TMP_InputField details;
    [SerializeField] TMP_InputField duration;
    [SerializeField] TMP_InputField cost;
    [SerializeField] TMP_InputField enchantdet;
    [SerializeField] TMP_InputField energycost;
    [SerializeField] TMP_InputField notes;
    [SerializeField] GameObject bootyButton;

    public void AddSpell()
    {
        GameObject bob = Instantiate(spellUIPrefab, WhereGo);
        QuickSpellView bobson = bob.GetComponent<QuickSpellView>();
        SpellPopup bobsonson = bob.GetComponent<SpellPopup>();
        Button bobsonsonson = bob.GetComponent<Button>();

        bobson.Spell = ScriptableObject.CreateInstance<Spell>();
        bobson.Spell.CastingTime = ScriptableObject.CreateInstance<ShortenableString>();
        bobson.Spell.MaintenanceCost = ScriptableObject.CreateInstance<ShortenableString>();
        bobson.Spell.SpellCost = ScriptableObject.CreateInstance<ShortenableString>();
        bobson.Spell.Duration = ScriptableObject.CreateInstance<ShortenableString>();
        bobson.Spell.EnchantmentInfo = ScriptableObject.CreateInstance<EnchantmentInfo>();
        bobson.Spell.CastingTime.ShortString = "1-3";
        bobson.Spell.SpellCost.ShortString = "1-3";

        bobsonson.lePopup = lePopup;
        bobsonson.header = header;
        bobsonson.body = body;
        bobsonson.spell = bobson;
        bobsonson.HeaderBackground = HeaderBackground;
        bobsonson.Title = Title;
        bobsonson.Colleges = Colleges;
        bobsonson.PageRef = PageRef;
        bobsonson.Type = Type;
        bobsonson.details = details;
        bobsonson.duration = duration;
        bobsonson.cost = cost;
        bobsonson.enchantdet = enchantdet;
        bobsonson.energycost = energycost;
        bobsonson.notes = notes;
        bobsonson.bootyButton = bootyButton;
        bobsonson.time = 0.4f;

        bobsonsonson.onClick.AddListener(() => bobsonson.Display(bobson.Spell));

        bobsonson.Display(bobson.Spell);
        bobsonson.Edit();
    }

}
