
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVR : MonoBehaviour {

    public static PlayerVR instance;
    private void Awake() {
        instance = this;
    }
    public Transform cabeza;

    public Transform manoDerecha;

    public Transform manoIzquierda;

    public float triggerDerecho;

    public Transform posicionCabeza;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
        manoIzquierda.localPosition = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.LeftHand);
        manoDerecha.localPosition = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.RightHand);

        manoIzquierda.localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.LeftHand);
        manoDerecha.localRotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.RightHand);

        if (Input.GetButtonDown("Fire2")) {
            RecolocarPlayer();
        }

        triggerDerecho = Input.GetAxis("TriggerDerecho");
    }

   
    
    public void RecolocarPlayer() {
        Vector3 posCamara = posicionCabeza.position;
        Vector3 movimiento = posCamara - cabeza.position;
        transform.position += movimiento;
    }

    
}
