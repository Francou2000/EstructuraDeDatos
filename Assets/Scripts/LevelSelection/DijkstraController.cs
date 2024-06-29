using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraController : MonoBehaviour
{
    private DijkstraAlg myDijkstra;
    public GrafoMA myGrafo;
    // Start is called before the first frame update
    void Start()
    {
        myGrafo = GetComponent<LS_GrafosController>().my_LS_Grafo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
