using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fib2 : MonoBehaviour {
    public int n;
    private int nAux;
    public MeshRenderer prefab;
    
    void Start(){
        nAux = n;
        InstanciarPuntos();
    }
    
    private Vector3[] EsferaFibonacci2(int num) {
        Vector3[] directions = new Vector3[num];
        //Factor del numero aureo 1.618033989
        float goldenRatio = (1 + Mathf.Sqrt (5)) / 2;
        //Aumentamos el angulo del rayo en funcion de pi y del numero aureo
        float angleIncrement = Mathf.PI * 2 * goldenRatio;
        //Calculamos el vector del rayo
        for (int i = 0; i < n; i++) {
            float t = (float) i / num;
            float inclination = Mathf.Acos (1 - 2 * t);
            float azimuth = angleIncrement * i;

            float x = Mathf.Sin (inclination) * Mathf.Cos (azimuth);
            float y = Mathf.Sin (inclination) * Mathf.Sin (azimuth);
            float z = Mathf.Cos (inclination);
            directions[i] = new Vector3 (x, y, z);
        }
        return directions;
    }

    void InstanciarPuntos () {
        //Vector con las direcciones de los rayos en funcion del numero aureo
        Vector3[] rayDirections = EsferaFibonacci2(n);
        //Si un rayo NO golpea, nos movemos en esa direccion
        for (int i = 0; i < rayDirections.Length; i++) {
            //Posiciones corregidas para que se vean separadas
            //Vector3 pos = Vector3.Scale(rayDirections[i], transform.localScale) + transform.position;
            Vector3 pos = (rayDirections[i] + transform.position);
            Quaternion q = new Quaternion(0,0,0,0);
            Instantiate(prefab, pos, q);
        }
    }

    void Update(){
        if(n!=nAux){
            LimpiarPrefabsMundo();
            nAux=n;
            InstanciarPuntos();
        }
    }

    //Eliminamos todos los puntos anteriores
    void LimpiarPrefabsMundo(){
        GameObject[] esferas;
        esferas = GameObject.FindGameObjectsWithTag("Fib2");
        foreach(GameObject e in esferas){
            Destroy(e);
        }
    }
    //Funcion para alterar la n desde el correspondiente slider
    public void CambiarN(float num){
        n=(int) num;
    }
}
