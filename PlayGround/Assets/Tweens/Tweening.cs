using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tweening : MonoBehaviour
{

    public Transform PointA;
    public Transform PointB;
    private MeshRenderer rend;


    // Start is called before the first frame update
    void Start()
    {
        //Get components and set color.
        rend = GetComponent<MeshRenderer>();
        rend.material.color = Color.blue;

        //Move sphere to first point.
        transform.position = PointA.transform.position;


        //Create a sequence variable for our tweens.
        Sequence mySequence = DOTween.Sequence();
          
        //Create the tween for moving.
        mySequence.Append(transform.DOMove(PointB.transform.position, 2).SetEase(Ease.InBounce));

        mySequence.Append(rend.material.DOColor(Color.green, 2).SetEase(Ease.InOutSine));

        //Scale up the sphere
        mySequence.Append(transform.DOScale(Vector3.one * 2, 2).SetEase(Ease.InOutSine));

        mySequence.Insert(6, transform.DOMove(PointA.transform.position, 2).SetEase(Ease.InOutFlash));
        mySequence.Insert(6, rend.material.DOColor(Color.blue, 2).SetEase(Ease.InOutSine));
        mySequence.Insert(6, transform.DOScale(Vector3.one, 2).SetEase(Ease.InOutSine));

        mySequence.OnComplete(EndOfSequence);

        DOVirtual.Float(0, 10, 3, ShowFloat);   
    
    }

    void ShowFloat(float f)
    {
        Debug.Log(f);
    }
    
    void EndOfSequence()
    {
        Debug.Log("Sequence has ended.");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
