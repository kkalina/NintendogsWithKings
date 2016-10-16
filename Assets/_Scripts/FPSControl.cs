using UnityEngine;
using System.Collections;

public class FPSControl : MonoBehaviour {

    public enum Weapons { Mine_Launcher, Cannon };
    private Weapons currentWeapon;
    public Weapons selectedWeapon;

    public GameObject cannon;
    public GameObject mineLauncher;

	Transform camTrans;

	public float	vertMult=0.5f, vertMin=-30, vertMax=30;
	public float	horizMult=0.5f;
	public float	speed = 10;
	
	public Vector3 	rot;
	public Vector3 	camRot;
	Rigidbody 		rigid;

    public GameObject CameraMount;
    public GameObject MineLauncherIronSight;
    public GameObject GameOverCanvas;
    public GameObject King;

    public int damage = 0;

	// Use this for initialization
	void Start () {
		camTrans = transform.Find ("Camera");
		rigid = GetComponent<Rigidbody>();
		//GameOverCanvas.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedWeapon = Weapons.Mine_Launcher;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedWeapon = Weapons.Cannon;
        rot = transform.localRotation.eulerAngles;
		camRot = camTrans.localRotation.eulerAngles;
		if (camRot.x > 180) camRot.x -= 360;
		
		float mDeltaX = Input.GetAxis("Mouse X");
		float mDeltaY = Input.GetAxis("Mouse Y");

		//print ("mX:"+mDeltaX+"    mY:"+mDeltaY);

		camRot.x -= mDeltaY * vertMult;
		camRot.x = Mathf.Clamp(camRot.x, vertMin, vertMax);

		rot.y += mDeltaX * horizMult;

		transform.localRotation = Quaternion.Euler(rot);
		camTrans.localRotation = Quaternion.Euler(camRot);

		if (King.GetComponent<KingNav>().health < 0) {
			GameOverCanvas.SetActive(true);
		}
	}

	void FixedUpdate() {

        if(selectedWeapon != currentWeapon)
        {
            if (selectedWeapon == Weapons.Cannon)
            {
                cannon.SetActive(true);
                mineLauncher.SetActive(false);
            }
            else if(selectedWeapon == Weapons.Mine_Launcher)
            {
                cannon.SetActive(false);
                mineLauncher.SetActive(true);
            }
            currentWeapon = selectedWeapon;
        }

		float vX = Input.GetAxis("Horizontal");
		float vY = Input.GetAxis("Vertical");

		Vector3 vel = Vector3.zero;
		vel += transform.forward * vY;
		vel += transform.right * vX;
		vel *= speed;
		vel.y = rigid.velocity.y;

		rigid.velocity = vel;

        if((Mathf.Abs(vX) > 0) || (Mathf.Abs(vY) > 0))
        {
            CameraMount.GetComponent<Animator>().SetBool("walking", true);
            MineLauncherIronSight.GetComponent<Animator>().SetBool("walking", true);
        }
        else
        {

            CameraMount.GetComponent<Animator>().SetBool("walking", false);
            MineLauncherIronSight.GetComponent<Animator>().SetBool("walking", false);
        }
	}
}
