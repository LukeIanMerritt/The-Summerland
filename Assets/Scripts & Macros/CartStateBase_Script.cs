using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartStateBase_Script : MonoBehaviour
{
    private GameObject cart;
    public GameObject GetCartObject(GameObject obj)
    {
        if (cart == null)
        {
            cart = gameObject;
        }
        return cart;
    }
}
