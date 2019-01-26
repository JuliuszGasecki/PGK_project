using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    private const int FIRSTELEMENT = 0;

    //private const int SECONDELEMENT = 1;
    //private const int THIRDELEMENT = 2;
    private const int INVENTORYCAPACITY = 3;
    private const int SPECIALINVENTORYCAPACITY = 1;
    private const int DRUGSMIXLISTCAPACITY = 7;
    private Animator _heroAnimatior;
    private int _usingSlot;
    private int _secondWeaponPosition;
    private int _thirdWeaponPosition;
    private NarcoManager _narcoManager;
    public int RifleAmmo { set; get; }
    public int ShotgunAmmo { set; get; }
    public int DeagleAmmo { set; get; }

    private enum _weaponsID
    {
        DEAGLE,
        M4,
        UMP45,
        SPAS12,
        KNIFE,
        CROSSBOW
    };


    public List<IWeapon> inventory;
    private List<ISpecialWeapon> specialWeapons;
    public IWeapon SecondWeapon = null;
    public IWeapon ThirdWeapon = null;
    private List<bool> _drugsMixList;

    private List<bool> _drugsMixListTemp;

    // Use this for initialization
    void Start()
    {
        //_heroAnimatior = GetComponent<Animator>();
        _heroAnimatior = GameObject.Find("Hero").GetComponent<Animator>();
        _narcoManager = GameObject.Find("NarcoManager").GetComponent<NarcoManager>();
        FillDrugsMix();
        RifleAmmo = 30;
        ShotgunAmmo = 15;
        DeagleAmmo = 10;
        inventory = new List<IWeapon>();
        specialWeapons = new List<ISpecialWeapon>();
        AddToList(this.gameObject.GetComponent<DEAGLE>());
        inventory.ElementAt(FIRSTELEMENT).CanUse = true;
        _usingSlot = 0;
        _secondWeaponPosition = _usingSlot + 1;
        _thirdWeaponPosition = _usingSlot + 2;
        //_heroAnimatior.SetBool("changingWeapon", true);
        //_heroAnimatior.SetInteger("weaponID", _usingSlot);
    }

    // Update is called once per frame
    void Update()
    {
        CheckDrugsMix();
        UseWeapon();
        if (IsSecondWeapon())
        {
            SecondWeapon = inventory.ElementAt(_secondWeaponPosition);
        }

        if (IsThirdWeapon())
        {
            ThirdWeapon = inventory.ElementAt(_thirdWeaponPosition);
        }

        RemoveFromInventory();
        //Debug.Log(DeagleAmmo);
    }

    private void SetWeaponActivity(int avoid)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (i == avoid)
            {
                inventory.ElementAt(i).CanUse = true;
                continue;
            }

            inventory.ElementAt(i).CanUse = false;
        }
    }

    private void UseWeapon()
    {
        #region Com

        /*if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.Count >= 1)
        {          
            _usingSlot = 0;
            _heroAnimatior.SetInteger("weaponID", inventory.ElementAt(FIRSTELEMENT).ID);
            _heroAnimatior.SetBool("changingWeapon", true);
            SetWeaponActivity(_usingSlot);
            inventory.ElementAt(FIRSTELEMENT).UseWeapon();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inventory.Count >= 2)
        {
            _usingSlot = 1;
            _heroAnimatior.SetInteger("weaponID", inventory.ElementAt(SECONDELEMENT).ID);
            _heroAnimatior.SetBool("changingWeapon", true);
            SetWeaponActivity(_usingSlot);
            inventory.ElementAt(SECONDELEMENT).UseWeapon();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && inventory.Count == 3)
        {            
            _usingSlot = 2;
            _heroAnimatior.SetInteger("weaponID", inventory.ElementAt(THIRDELEMENT).ID);
            _heroAnimatior.SetBool("changingWeapon", true);
            SetWeaponActivity(_usingSlot);
            inventory.ElementAt(THIRDELEMENT).UseWeapon();
            return;
        }*/

        #endregion

        if (Input.GetAxis("Mouse ScrollWheel") < 0f && inventory.Any())
        {
            _usingSlot++;
            //if (_usingSlot > 2 || _usingSlot > inventory.Count-1)
            CheckUpperLimit();
            SetWeaponActivity(_usingSlot);
            inventory.ElementAt(_usingSlot).UseWeapon();
            _heroAnimatior.SetBool("changingWeapon", true);
            _heroAnimatior.SetInteger("weaponID", _usingSlot);
            return;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && inventory.Any())
        {
            _usingSlot--;
            CheckLowerLimit();
            SetWeaponActivity(_usingSlot);
            inventory.ElementAt(_usingSlot).UseWeapon();
            _heroAnimatior.SetBool("changingWeapon", true);
            _heroAnimatior.SetInteger("weaponID", _usingSlot);
            return;
        }
    }

    private void CheckUpperLimit()
    {
        if (_usingSlot > inventory.Count - 1)
        {
            _usingSlot = 0;
        }

        _secondWeaponPosition = _usingSlot + 1;
        if (_secondWeaponPosition > inventory.Count - 1)
        {
            _secondWeaponPosition = 0;
        }

        _thirdWeaponPosition = _secondWeaponPosition + 1;
        if (_thirdWeaponPosition > inventory.Count - 1)
        {
            _thirdWeaponPosition = 0;
        }
    }

    private void CheckLowerLimit()
    {
        if (_usingSlot < 0)
        {
            _usingSlot = inventory.Count - 1;
        }

        _secondWeaponPosition--;
        if (_secondWeaponPosition < 0)
        {
            _secondWeaponPosition = inventory.Count - 1;
        }

        _thirdWeaponPosition--;
        if (_thirdWeaponPosition < 0)
        {
            _thirdWeaponPosition = inventory.Count - 1;
        }
    }

    private void RemoveFromInventory()
    {
        if (Input.GetKeyDown(KeyCode.G) && inventory.Any())
        {
            inventory.ElementAt(_usingSlot).DeafultAmmo();
            inventory.ElementAt(_usingSlot).CanUse = false;
            inventory.RemoveAt(_usingSlot);
            _usingSlot--;
            if (_usingSlot < 0)
            {
                _usingSlot = 0;
            }

            _secondWeaponPosition = _usingSlot + 1;
            if (_secondWeaponPosition > inventory.Count - 1)
            {
                _secondWeaponPosition = 0;
            }

            _thirdWeaponPosition = _usingSlot + 2;
            if (_thirdWeaponPosition > inventory.Count - 1)
            {
                _thirdWeaponPosition = 0;
            }

            SetWeaponActivity(_usingSlot);
            _heroAnimatior.SetBool("changingWeapon", true);
            _heroAnimatior.SetInteger("weaponID", _usingSlot);
        }
    }

    public bool IsSecondWeapon()
    {
        if (inventory.Count >= 2)
        {
            return true;
        }

        return false;
    }

    public bool IsThirdWeapon()
    {
        if (inventory.Count == INVENTORYCAPACITY)
        {
            return true;
        }

        return false;
    }

    public bool AddToList(IWeapon weapon)
    {
        if (Enum.IsDefined(typeof(_weaponsID), weapon.ID) && inventory.Count < INVENTORYCAPACITY)
        {
            inventory.Add(weapon);
//            Debug.Log(_usingSlot);
            if (inventory.Count == 1)
            {
                SetWeaponActivity(0);
            }

            if (inventory.Count == 2)
            {
                _secondWeaponPosition = 1;
                if (_secondWeaponPosition > inventory.Count - 1)
                {
                    _secondWeaponPosition = 0;
                }
            }

            if (inventory.Count == 3)
            {
                _thirdWeaponPosition = 2;
                if (_thirdWeaponPosition > inventory.Count - 1)
                {
                    _thirdWeaponPosition = 0;
                }
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddSpecialWeapon(ISpecialWeapon weapon)
    {
        if (Enum.IsDefined(typeof(_weaponsID), weapon.ID) && specialWeapons.Count < SPECIALINVENTORYCAPACITY)
        {
            specialWeapons.Add(weapon);
            weapon.CanUse = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public ISpecialWeapon GetUsingSpecialWeapon()
    {
        if (specialWeapons.Any())
        {
            return specialWeapons.ElementAt(0);
        }

        return null;
    }

    public List<IWeapon> GetInventory()
    {
        return inventory;
    }

    public IWeapon GetUsingWeapon()
    {
        if (inventory.Any())
        {
            return inventory.ElementAt(_usingSlot);
        }

        return null;
    }

    public bool IsAdded(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
            if (inventory[i].ID == id)
                return true;
        return false;
    }

    public bool isAlert()
    {
        if (inventory.Exists((obj) => obj.alert == true))
            return true;
        return false;
    }

    public void FillDrugsMix()
    {
        _drugsMixList = new List<bool>();
        for (int i = 0; i < DRUGSMIXLISTCAPACITY; i++)
        {
            _drugsMixList.Add(false);
        }

        _drugsMixListTemp = new List<bool>(_drugsMixList);
    }

    public void CheckDrugsMix()
    {
        _drugsMixList[0] = _narcoManager.alcoHeraFlag;
        _drugsMixList[1] = _narcoManager.cocoHeraFlag;
        //_drugsMixList[2] = _narcoManager.alcoSpeedFlag;
        //_drugsMixList[3] = _narcoManager.cocoMaryFlag;
        //_drugsMixList[4] = _narcoManager.cocoMDMAFlag;
        //_drugsMixList[5] = _narcoManager.cocoLSDFlag;
        //_drugsMixList[6] = _narcoManager.maryCigarFlag;
    }

    public int ReturnDrugsMix()
    {
        for (int i = 0; i < DRUGSMIXLISTCAPACITY; i++)
            if (_drugsMixList[i] && _drugsMixListTemp[i] == !_drugsMixList[i])
            {
                _drugsMixListTemp[i] = _drugsMixList[i];
                return i;
            }

        for (int i = 0; i < DRUGSMIXLISTCAPACITY; i++)
            if (_drugsMixListTemp[i] && _drugsMixList[i] == false)
            {
                _drugsMixListTemp[i] = false;
            }

        return -1;
    }
}