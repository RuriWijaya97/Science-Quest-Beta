using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite part1, part2, part3;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        part1 = Resources.Load<Sprite>("Part1");
        part2 = Resources.Load<Sprite>("Part2");
        part3 = Resources.Load<Sprite>("Part3");
        rend.sprite = part1;
    }

    // Update is called once per frame
    void Update()
    {
        Next();
    }

    public void Next() {
        if (rend.sprite == part1)
            rend.sprite = part2;
        else if (rend.sprite == part2)
            rend.sprite = part3;
        else if (rend.sprite == part3)
            rend.sprite = part1;
    }
}
