using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    private bool CooldownBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (!CooldownBool && Input.GetMouseButton(1)) { StartCoroutine(Cooldown()); }
    }

    IEnumerator Cooldown()
    {
        CooldownBool = true;
        yield return new WaitForSeconds(0.001f);
        Vector2 direction =  Camera.main.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Camera.main.transform.position += new Vector3(direction.x * -0.01f, direction.y * -0.01f, 0);
        CooldownBool = false;
    }
}
