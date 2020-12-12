using GUST.Spells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellPopup : Popup<Spell>
{
    [SerializeField] public GameObject lePopup;
    [SerializeField] public GameObject header;
    [SerializeField] public GameObject body;
    [SerializeField] public QuickSpellView spell;
    [SerializeField] public GameObject HeaderBackground;
    [SerializeField] public TMP_InputField Title;
    [SerializeField] public TMP_InputField Colleges;
    [SerializeField] public TMP_InputField PageRef;
    [SerializeField] public TMP_InputField Type;
    [SerializeField] public TMP_InputField details;
    [SerializeField] public TMP_InputField duration;
    [SerializeField] public TMP_InputField cost;
    [SerializeField] public TMP_InputField enchantdet;
    [SerializeField] public TMP_InputField energycost;
    [SerializeField] public TMP_InputField notes;
    [SerializeField] public GameObject bootyButton;
    [SerializeField] public float time = 1;
    private static Spell disp = null;
    [SerializeField] public int test = 0;


    private void Awake()
    {
        if (test == 1)
        {
            lePopup.SetActive(false);
        }
    }

    public override void Display(Spell displayayyyy)
    {
        disp = displayayyyy;
        HeaderBackground.GetComponent<Image>().color = new Color(255,0,0);
        Title.text = displayayyyy.Name;
        Colleges.text = displayayyyy.GetCollegesString();
        PageRef.text = displayayyyy.PageRef;
        Type.text = displayayyyy.SpellClass;
        details.text = displayayyyy.Description;
        duration.text = displayayyyy.Duration.DetailedString;
        cost.text = displayayyyy.SpellCost.DetailedString;
        enchantdet.text = displayayyyy.EnchantmentInfo.Details;
        energycost.text = displayayyyy.EnchantmentInfo.Cost;
        notes.text = displayayyyy.Notes;
        lePopup.SetActive(true);
        header.transform.position = spell.transform.position;
        StartCoroutine(nameof(Move));
    }

    public void Leave()
    {
        StartCoroutine(nameof(Close));
    }

    private IEnumerator Move()
    {
        Vector3 tstart = header.transform.localPosition;
        Vector3 tend = new Vector3(0,-100,0);
        Vector3 tstart2 = Title.gameObject.transform.localPosition;
        Vector3 tend2 = Title.gameObject.transform.localPosition;
        Image botybtn = bootyButton.GetComponent<Image>();
        Color color = botybtn.color;
        tend2.x += 85;
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            header.transform.localPosition = Vector3.Lerp(tstart, tend, t / time);
            Title.gameObject.transform.localPosition = Vector3.Lerp(tstart2, tend2, t / time);
            color.a = t / time;
            botybtn.color = color;
            yield return null;
        }
        header.transform.localPosition = tend;
        body.transform.localPosition = new Vector3(0, 367, 0);

        tstart = body.transform.localPosition;
        tend = new Vector3(0, -767, 0);
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            body.transform.localPosition = Vector3.Lerp(tstart, tend, t / time);
            yield return null;
        }
        body.transform.localPosition = tend;
    }

    private IEnumerator Close()
    {
        Vector3 tstart = header.transform.position;
        Vector3 tend = tstart;
        tend.x += header.GetComponent<RectTransform>().rect.width;

        Vector3 tstart2 = body.transform.position;
        Vector3 tend2 = tstart2;
        tend2.x += body.GetComponent<RectTransform>().rect.width;

        for (float t = 0; t < time; t += Time.deltaTime)
        {
            header.transform.position = Vector3.Lerp(tstart, tend, t / time);
            body.transform.position = Vector3.Lerp(tstart2, tend2, t / time);
            yield return null;
        }
        header.transform.position = tend;
        body.transform.position = tend2;
        lePopup.SetActive(false);
        header.transform.localPosition = new Vector3(0, -100, 0);
        body.transform.localPosition = new Vector3(0, 567, 0);
        Title.GetComponent<RectTransform>().anchoredPosition = new Vector3(240, -72, 0);

    }

    public void Edit()
    {
        Title.interactable = !Title.interactable;
        Title.textComponent.color = Title.interactable ? new Color(0, 0, 0) : new Color(255, 255, 255);
        Colleges.interactable = !Colleges.interactable;
        Colleges.textComponent.color = Title.interactable ? new Color(0, 0, 0) : new Color(255, 255, 255);
        PageRef.interactable = !PageRef.interactable;
        PageRef.textComponent.color = Title.interactable ? new Color(0, 0, 0) : new Color(255, 255, 255);
        Type.interactable = !Type.interactable;
        details.interactable = !details.interactable;
        duration.interactable = !duration.interactable;
        cost.interactable = !cost.interactable;
        enchantdet.interactable = !enchantdet.interactable;
        energycost.interactable = !energycost.interactable;

        disp.Name = Title.text;
        disp.Clear();
        disp.AddCollege(Colleges.text);
        disp.PageRef = PageRef.text;
        disp.SpellClass = Type.text;
        disp.Description = details.text;
        disp.Duration.DetailedString = duration.text;
        disp.SpellCost.DetailedString = cost.text;
        disp.EnchantmentInfo.Details = enchantdet.text;
        disp.EnchantmentInfo.Cost = energycost.text;
    }

}
