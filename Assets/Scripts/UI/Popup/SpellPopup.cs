using GUST.Spells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellPopup : Popup<Spell>
{
    [SerializeField] GameObject lePopup;
    [SerializeField] GameObject header;
    [SerializeField] GameObject body;
    [SerializeField] QuickSpellView spell;
    [SerializeField] GameObject HeaderBackground;
    [SerializeField] TMP_InputField Title;
    [SerializeField] TMP_InputField Colleges;
    [SerializeField] TMP_InputField PageRef;
    [SerializeField] GameObject bootyButton;
    [SerializeField] float time = 1;

    public override void Display(Spell displayayyyy)
    {
        HeaderBackground.GetComponent<Image>().color = spell.GetComponent<Image>().color;
        Title.text = displayayyyy.Name;
        Colleges.text = displayayyyy.GetCollegesString();
        PageRef.text = displayayyyy.PageRef;
        header.transform.position = spell.transform.position;
        lePopup.SetActive(true);
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

}
