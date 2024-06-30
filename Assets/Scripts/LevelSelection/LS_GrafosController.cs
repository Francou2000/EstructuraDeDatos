using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LS_GrafosController : MonoBehaviour
{
    public VerticeData[] vertices;
    public AristaData[] aristas;
    public LS_PlayerMovement Player;

    public GrafoMA my_LS_Grafo;
    private DijkstraAlg myDijkstra;

    private int[] nodosARecorrer;
    private int nodosRecorridos = 0;

    public GameObject myRaycaster;

    void Start()
    {
        my_LS_Grafo = new GrafoMA();
        my_LS_Grafo.InicializarGrafo();

        for (int i = 0; i < vertices.Length; i++)
        {
            my_LS_Grafo.AgregarVertice((int)vertices[i].myLevelName);
        }
        for (int i = 0;i < aristas.Length; i++)
        {
            my_LS_Grafo.AgregarArista((int)aristas[i].myConectionName1, (int)aristas[i].myConectionName2, 1);
            my_LS_Grafo.AgregarArista((int)aristas[i].myConectionName2, (int)aristas[i].myConectionName1, 1);
        }
        
        myDijkstra = new DijkstraAlg();

        Player.Arrived.AddListener(SetObjPositionsToPlayer);
    }


    public void MoveToVertice(VerticesID VerticeObj)
    {
        myRaycaster.GetComponent<Physics2DRaycaster>().enabled = false;
        int verticeObj = (int)VerticeObj;
        myDijkstra.Dijkstra(my_LS_Grafo, (int)Player.actualVertice);

        string[] recorrido = myDijkstra.nodos[verticeObj].Split(",");

        nodosARecorrer = new int[recorrido.Length];
        for (int i = 0; i < recorrido.Length; i++)
        {
            nodosARecorrer[i] = Convert.ToInt32(recorrido[i]);
        }
        nodosRecorridos = 0;
        SetObjPositionsToPlayer();
    }

    private void SetObjPositionsToPlayer()
    {
        if (nodosRecorridos < nodosARecorrer.Length)
        {
            float x = vertices[nodosARecorrer[nodosRecorridos]].gameObject.transform.position.x;
            float y = vertices[nodosARecorrer[nodosRecorridos]].gameObject.transform.position.y;
            nodosRecorridos++;
            Player.SetObjPosition(x, y);
            
        }
        else
        {
            Player.actualVertice = vertices[nodosARecorrer[nodosRecorridos - 1]].myLevelName;
            vertices[nodosARecorrer[nodosRecorridos - 1]].OpenPlayMenu();
        }
        
    }

    public void ClosePlayMenu()
    {
        vertices[0].playMenu.SetActive(false);
        myRaycaster.GetComponent<Physics2DRaycaster>().enabled = true;
    }

}
