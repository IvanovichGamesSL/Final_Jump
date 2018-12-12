using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour {
    public Rigidbody m_Rigidbody;
    public Animator m_Animator;
    public float fuerzaEmpuje;
    public Transform direccionEmpuje;

    public PuppetMaster m_puppetMaster;

    Vector3 inicio;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0.5f;
        inicio = transform.position;
        puedoSaltar = false;
    }

    // Update is called once per frame
    bool puedoSaltar = false;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            m_Rigidbody.AddForce(direccionEmpuje.forward * fuerzaEmpuje, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            m_Rigidbody.transform.position = inicio;
            m_Rigidbody.transform.rotation = Quaternion.identity;
            
        }

        if (puedoSaltar && Input.GetAxis("Horizontal") < 0.9f) {
            puedoSaltar = false;
            m_Animator.SetTrigger("Saltar");
            m_Rigidbody.AddForce(direccionEmpuje.forward * fuerzaEmpuje, ForceMode.Impulse);
        }
        if (Input.GetAxis("Horizontal") >= 0.9f) {
            puedoSaltar = true;
        }

        if (!puedoSaltar && Input.GetAxis("Horizontal") > 0.9f) {

        }
        m_Animator.SetFloat("Agachado",Input.GetAxis("Horizontal"));
    }
}
