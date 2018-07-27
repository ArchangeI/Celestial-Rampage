using UnityEngine;
using System.Collections;

public class GunEquipper : MonoBehaviour {

	public static string activeWeaponType;
	public GameObject pistol;
	public GameObject assaultRifle;
	public GameObject shotgun;

	[SerializeField]
	GameUI gameUI;
	GameObject activeGun;
	[SerializeField]
	Ammo ammo;

	// Use this for initialization
	void Start () {
	activeWeaponType = Constants.Pistol;
	activeGun = pistol;
}
	
	// Update is called once per frame
	void Update() {
	  if (Input.GetKeyDown("1")) {
	    loadWeapon(pistol);
	    activeWeaponType = Constants.Pistol;
	    gameUI.UpdateReticle();
	  } else if (Input.GetKeyDown("2")) {
	    loadWeapon(assaultRifle);
	    activeWeaponType = Constants.AssaultRifle;
	    gameUI.UpdateReticle();
	  } else if (Input.GetKeyDown("3")) {
	    loadWeapon(shotgun);
	    activeWeaponType = Constants.Shotgun;
	    gameUI.UpdateReticle();
	  }
	}

	private void loadWeapon(GameObject weapon) {
	  pistol.SetActive(false);
	  assaultRifle.SetActive(false);
	  shotgun.SetActive(false);

	  weapon.SetActive(true);
	  activeGun = weapon;
		gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
	}

	public GameObject GetActiveWeapon() {
  	return activeGun;
	}

}
