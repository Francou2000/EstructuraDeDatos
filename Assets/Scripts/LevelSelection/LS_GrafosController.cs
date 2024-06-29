using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class LS_GrafosController : MonoBehaviour
{
    public VerticeData[] vertices;
    public AristaData[] aristas;
    public LS_PlayerMovement Player;

    public GrafoMA my_LS_Grafo;
    private DijkstraAlg myDijkstra;

    private int[] nodosARecorrer;
    private int nodosRecorridos = 0;

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
        int verticeObj = (int)VerticeObj;
        myDijkstra.Dijkstra(my_LS_Grafo, (int)Player.actualVertice);

        string[] recorrido = myDijkstra.nodos[verticeObj].Split(",");

        nodosARecorrer = new int[recorrido.Length];
        for (int i = 0; i < recorrido.Length; i++)
        {
            nodosARecorrer[i] = Convert.ToInt32(recorrido[i]);
            Debug.Log(recorrido[i]);
        }
        nodosRecorridos = 0;
        SetObjPositionsToPlayer();

        //----------------------------------------------------------------------------------------------------------------------
        MuestroResultadosAlg(myDijkstra.distance, my_LS_Grafo.cantNodos, my_LS_Grafo.Etiqs, myDijkstra.nodos);

    }

    public static void MuestroResultadosAlg(int[] distance, int verticesCount, int[] Etiqs, string[] caminos)
    {
        string distancia = "";

        Debug.Log("Vertice    Distancia desde origen    Nodos");

        for (int i = 0; i < verticesCount; ++i)
        {
            if (distance[i] == int.MaxValue)
            {
                distancia = "---";
            }
            else
            {
                distancia = distance[i].ToString();
            }
            string a = Etiqs[i] + "   " + distancia + "   " + caminos[i];
            Debug.Log(a);
        }
    }

    //------------------------------------------------------------------------------------------------------------------------------
    //}

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
        }
        
    }

}
