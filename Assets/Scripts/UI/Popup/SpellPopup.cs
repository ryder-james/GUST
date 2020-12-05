using GUST.Spells;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPopup : Popup<Spell>
{
    [SerializeField] GameObject lePopup;
    [SerializeField] GameObject header;
    [SerializeField] GameObject body;
    [SerializeField] QuickSpellView spell;
    [SerializeField] float time = 1;

    public override void Display(Spell displayayyyy)
    {
        header.transform.position = spell.transform.position;
        lePopup.SetActive(true);
        StartCoroutine(nameof(Move));
    }

    private IEnumerator Move()
    {
        Vector3 tstart = header.transform.localPosition;
        Vector3 tend = new Vector3(0,-100,0);
        for (float t = 0; t < time; t += Time.deltaTime)
        {
            header.transform.localPosition = Vector3.Lerp(tstart, tend, t / time);
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

}
