using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    public int[] aOrdenar;
    private Sort sortTool = new Sort();

    void Start()
    {
        string a = "";
        foreach (int i in aOrdenar)
        {
            a += i.ToString() + ",";
        }

        
        string b = "";
        int[] ordenado1 = sortTool./*QuickSort*/QuickSort(aOrdenar, 0, aOrdenar.Length - 1);//HigherToLower(aOrdenar);
        foreach (int i in ordenado1) { b += i.ToString() + ","; }
        string c = "";
        //int[] ordenado2 = sortTool.LowerToHigher(aOrdenar);
        //foreach(int i in ordenado2) {  c += i.ToString() + ","; }

        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(c);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
