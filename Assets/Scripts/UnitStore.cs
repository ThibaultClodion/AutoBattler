using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitStore : MonoBehaviour
{
    [SerializeField] private Character[] payableUnits;
    private Character selectedUnit;

    [SerializeField] private Button unitButtonPrefab;
    [SerializeField] private GameObject unitVisualisation;
    [SerializeField] private LayerMask unitPlacableLayerMask;

    void Start()
    {
        selectedUnit = payableUnits[0];    // Ensure that one unit is selected
        CreateUnitButtons();
    }

    private void OnEnable()
    {
        if (unitVisualisation != null)
        {
            unitVisualisation.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if(unitVisualisation != null)
        {
            unitVisualisation.SetActive(false);
        }
    }

    private void Update()
    {
        MoveUnitVisualisationToMouse();

        //Create unit but not if player click on UI
        if (Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        {
            GameManager.InstantiateAlly(selectedUnit, unitVisualisation.transform.position, GameManager.kings[0] == null);
        }
    }

    private void MoveUnitVisualisationToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, unitPlacableLayerMask))
        {
            unitVisualisation.transform.position = hit.point;
        }
    }

    private void CreateUnitButtons()
    {
        foreach (Character character in payableUnits)
        {
            Button unitButton = Instantiate(unitButtonPrefab, transform);
            unitButton.onClick.AddListener(delegate { ChangeSelectedUnit(character); } );
        }
    }

    private void ChangeSelectedUnit(Character character)
    {
        selectedUnit = character;
    }
}