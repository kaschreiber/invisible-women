using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Rendering;
using UnityEngine.iOS;

public class PortalManager : MonoBehaviour
{
    private Camera MainCamera;

    public GameObject Sponza;
    public GameObject Book;
    public GameObject Castle;
    public GameObject Letter;
    public GameObject Feminism;
    public GameObject Physics;
    public GameObject Luck;

    private Material[] SponzaMaterials;
    private Material[] BookMaterials;
    private Material[] CastleMaterials;
    private Material[] LetterMaterials;
    private Material[] FeminismMaterials;
    private Material[] PhysicsMaterials;
    private Material[] LuckMaterials;

    private UIDocument uIDocument;
    private VisualElement footerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
        BookMaterials = Book.GetComponent<Renderer>().sharedMaterials;
        CastleMaterials = Castle.GetComponent<Renderer>().sharedMaterials;
        LetterMaterials = Letter.GetComponent<Renderer>().sharedMaterials;
        FeminismMaterials = Feminism.GetComponent<Renderer>().sharedMaterials;
        PhysicsMaterials = Physics.GetComponent<Renderer>().sharedMaterials;
        LuckMaterials = Luck.GetComponent<Renderer>().sharedMaterials;

        MainCamera = Camera.main;

        uIDocument = GameObject.Find("ScanUI").GetComponent<UIDocument>();
        footerDisplay = uIDocument.rootVisualElement.Q<VisualElement>("FooterAdvice");
    }

    // Update is called once per frame
    void OnTriggerStay (Collider collider)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if (camPositionInPortalSpace.y < 0.5f)
        {
            Label footerText = footerDisplay.Q<Label>("FooterText");
            footerText.text = "Tap on a pillar to get some information about the item.";

            for (int i = 0; i < SponzaMaterials.Length; i++)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            for (int i = 0; i < BookMaterials.Length; i++)
            {
                BookMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            for (int i = 0; i < CastleMaterials.Length; i++)
            {
                CastleMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            for (int i = 0; i < LetterMaterials.Length; i++)
            {
                LetterMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            for (int i = 0; i < FeminismMaterials.Length; i++)
            {
                FeminismMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            for (int i = 0; i < PhysicsMaterials.Length; i++)
            {
                PhysicsMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            for (int i = 0; i < LuckMaterials.Length; i++)
            {
                LuckMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
        }
        else
        {
            for (int i = 0; i < SponzaMaterials.Length; i++)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            for (int i = 0; i < BookMaterials.Length; i++)
            {
                BookMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            for (int i = 0; i < CastleMaterials.Length; i++)
            {
                CastleMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            for (int i = 0; i < LetterMaterials.Length; i++)
            {
                LetterMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            for (int i = 0; i < FeminismMaterials.Length; i++)
            {
                FeminismMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            for (int i = 0; i < PhysicsMaterials.Length; i++)
            {
                PhysicsMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            for (int i = 0; i < LuckMaterials.Length; i++)
            {
                LuckMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
        }
    }
}
