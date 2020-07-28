using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FibYo : MonoBehaviour {
    public int n;
    private int nAux;
    public int valorPrueba;
    public MeshRenderer prefab;
    // Start is called before the first frame update
    void Start(){
        valorPrueba=2;
        nAux = n;
        InstanciarPuntos();
    }

    private Vector3[] EsferaFibonacci(int numeroPuntos){
        Vector3[] puntos = new Vector3[numeroPuntos];
        var goldenN = (1 + Math.Pow(5,0.5)) / 2;
        for (int i = 0; i < numeroPuntos; i++){
            //Cuando cambias el 2 de delante pasan cosas raras y chulas en la generacion de terreno
            //var theta = 2 * Math.PI * (i/goldenN);
            var theta = valorPrueba * Math.PI * (i/goldenN);
            var phi = Math.Acos(1-2*(i+0.5f)/numeroPuntos);
            puntos[i] = new Vector3((float) Math.Cos(theta)* (float) Math.Sin(phi), (float) Math.Sin(theta)* (float) Math.Sin(phi), (float) Math.Cos(phi));
        }
        return puntos;
    }
    void InstanciarPuntos() {
        Vector3[] rayDirections = EsferaFibonacci(n);
        for (int i = 0; i < rayDirections.Length; i++) {
            //Vector3 pos = Vector3.Scale(rayDirections[i], transform.localScale) + transform.position;
            Vector3 pos = (rayDirections[i] + transform.position);
            Quaternion q = new Quaternion(0,0,0,0);
            Instantiate(prefab, pos, q);
        }
    }

    // Update is called once per frame
    void Update(){
        if(n!=nAux){
            LimpiarPrefabsMundo();
            nAux=n;
            InstanciarPuntos();
        }
    }
    void LimpiarPrefabsMundo(){
        GameObject[] esferas;
        esferas = GameObject.FindGameObjectsWithTag("FibYo");
        foreach(GameObject e in esferas){
            Destroy(e);
        }
    }

    public void CambiarN(float num){
        n=(int) num;
    }
    public void CambiarvalorPrueba(float num){
        valorPrueba=(int) num;
    }
}
