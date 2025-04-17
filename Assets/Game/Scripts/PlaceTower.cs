using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] private GameObject _towerPrefab;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(
                Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.
                    TryGetComponent(out Place place))
                {
                    if (!place.IsZanyato)
                    {
                        GameObject tower = Instantiate(_towerPrefab,
                            place.transform.position,
                            Quaternion.identity);
                        place.SetTower(tower.GetComponent<Tower>());

                    }
                }
            }
        }
    }
}
