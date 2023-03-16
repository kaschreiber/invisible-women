using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UIElements;

public class OpenInfoDisplay : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager m_RaycastManager;

    private List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    private Camera arCamera;
    private GameObject spawnedObject;
    // Start is called before the first frame update

    [SerializeField]
    private UIDocument infoUI;
    private VisualElement infoRoot;
    private VisualElement footerDisplay;

    [SerializeField]
    private UIDocument scanUI;
    private VisualElement scanRoot;
    private void Start()
    {
        //arCamera = GameObject.Find("AR Camera").GetComponent<Camera>();
        spawnedObject = null;
        arCamera = Camera.main;

        infoRoot = infoUI.rootVisualElement.Q<VisualElement>("InfoVisualElement");
        infoRoot.style.display = DisplayStyle.None;

        scanRoot = scanUI.rootVisualElement.Q<VisualElement>("ScanRoot");
        footerDisplay = scanRoot.Q<VisualElement>("FooterAdvice");

        Button closeButton = infoRoot.Q<Button>("CloseButton");
        closeButton.clicked += () => closePanel();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount == 0) return;

        RaycastHit hit;
        Ray ray = arCamera.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    // TODO: Refactor
                    if (hit.collider.gameObject.tag == "Book") {
                        // Add specific text to display
                        if (infoRoot.style.display == DisplayStyle.None) {
                            scanRoot.style.display = DisplayStyle.None;
                            VisualElement infoImage = infoRoot.Q<VisualElement>("InfoImage");
                            Texture2D texture = Resources.Load<Texture2D>("InfoBook");
                            infoImage.style.backgroundImage = texture;
                            infoRoot.style.display = DisplayStyle.Flex;
                            Label titleText = infoRoot.Q<Label>("InfoTitle");
                            titleText.text = "Philosophiæ Naturalis \n Principia Mathematica";
                            Label infoText = infoRoot.Q<Label>("InfoText");
                            infoText.text = "Émilie du Châtelet is best known for her translation of Isaac Newton's Philosophiæ Naturalis Principia Mathematica into French, which is still considered to be one of the most accurate translations of the work to this day. The translation, which took her several years to complete, was not only an accurate rendition of Newton's work but also included her own extensive commentary, which helped to clarify many of the concepts and principles discussed in the original text. Her translation and commentary are still regarded as a masterpiece of scientific literature and are studied by scholars to this day.";
                            Debug.Log("Set to None");
                            footerDisplay.style.display = DisplayStyle.None;
                            Debug.Log("Is None");
                        }
                    }

                    if (hit.collider.gameObject.tag == "Castle") {
                        // Add specific text to display
                        if (infoRoot.style.display == DisplayStyle.None) {
                            scanRoot.style.display = DisplayStyle.None;
                            VisualElement infoImage = infoRoot.Q<VisualElement>("InfoImage");
                            Texture2D texture = Resources.Load<Texture2D>("InfoCastle");
                            infoImage.style.backgroundImage = texture;
                            infoRoot.style.display = DisplayStyle.Flex;
                            Label titleText = infoRoot.Q<Label>("InfoTitle");
                            titleText.text = "Castle Cirey";
                            Label infoText = infoRoot.Q<Label>("InfoText");
                            infoText.text = "Émilie du Châtelet lived at Cirey Castle in Lorraine from 1734 until her death in 1749, together with her lover Voltaire. The château served as a place of scientific and intellectual exchange and offered Émilie du Châtelet the opportunity to study mathematics, physics and philosophy in depth. During her time at Cirey Castle, she worked on her most famous work, \"Institutions de Physique\". The château also offered the opportunity to conduct experiments, especially in the field of optics and vacuum experiments.";
                            Debug.Log("Set to None");
                            footerDisplay.style.display = DisplayStyle.None;
                            Debug.Log("Is None");
                        }
                    }

                    if (hit.collider.gameObject.tag == "Letter") {
                        // Add specific text to display
                        if (infoRoot.style.display == DisplayStyle.None) {
                            scanRoot.style.display = DisplayStyle.None;
                            VisualElement infoImage = infoRoot.Q<VisualElement>("InfoImage");
                            Texture2D texture = Resources.Load<Texture2D>("InfoLetter");
                            infoImage.style.backgroundImage = texture;
                            infoRoot.style.display = DisplayStyle.Flex;
                            Label titleText = infoRoot.Q<Label>("InfoTitle");
                            titleText.text = "Pen friendship with \n Friedrich II";
                            Label infoText = infoRoot.Q<Label>("InfoText");
                            infoText.text = "Émilie du Châtelet and Friedrich der Große, King of Prussia, were pen pals and shared a passion for mathematics and philosophy. The two never met in person, but their letters reflect their intellectual bond. Émilie du Châtelet discussed with him topics such as the nature of matter, the role of faith and reason, and the ideas of the Enlightenment. He valued Émilie du Châtelet's intelligence and scientific contributions and supported her work by providing financial resources and books and instruments. The letters between them are an important part of their intellectual heritage and show how Enlightenment ideas and the Scientific Revolution shaped Europe.";
                            Debug.Log("Set to None");
                            footerDisplay.style.display = DisplayStyle.None;
                            Debug.Log("Is None");
                        }
                    }

                    if (hit.collider.gameObject.tag == "Feminism") {
                        // Add specific text to display
                        if (infoRoot.style.display == DisplayStyle.None) {
                            scanRoot.style.display = DisplayStyle.None;
                            VisualElement infoImage = infoRoot.Q<VisualElement>("InfoImage");
                            Texture2D texture = Resources.Load<Texture2D>("InfoFeminism");
                            infoImage.style.backgroundImage = texture;
                            infoRoot.style.display = DisplayStyle.Flex;
                            Label titleText = infoRoot.Q<Label>("InfoTitle");
                            titleText.text = "Effect on modern \n feminism";
                            Label infoText = infoRoot.Q<Label>("InfoText");
                            infoText.text = "Émilie du Châtelet lived according to the conventions of her time, and in this respect it would be wrong to characterise her as a pioneer of feminism, but she had many criticisms of the position of women in her society. She wrote in \"Discours sur le bonheur\" that many paths to happiness were open to men, for example in the arts of war or diplomacy. For women, on the other hand, only study remained. In her translation of Mandeville's \"The Fable of the Bees\" she is more explicit in a commentary: \"If I were king, I would abolish an abuse that sets back half of humanity. I would let women share in all human rights, especially spiritual ones.";
                            Debug.Log("Set to None");
                            footerDisplay.style.display = DisplayStyle.None;
                            Debug.Log("Is None");
                        }
                    }

                    if (hit.collider.gameObject.tag == "Physics") {
                        // Add specific text to display
                        if (infoRoot.style.display == DisplayStyle.None) {
                            scanRoot.style.display = DisplayStyle.None;
                            VisualElement infoImage = infoRoot.Q<VisualElement>("InfoImage");
                            Texture2D texture = Resources.Load<Texture2D>("InfoPhysics");
                            infoImage.style.backgroundImage = texture;
                            infoRoot.style.display = DisplayStyle.Flex;
                            Label titleText = infoRoot.Q<Label>("InfoTitle");
                            titleText.text = "Institutions de \n Physique";
                            Label infoText = infoRoot.Q<Label>("InfoText");
                            infoText.text = "Émilie du Châtelet wrote the book, \"Institutions de Physique\", which was published anonymously in 1740. It was not published until 1742 with her name. This book provided a comprehensive overview of the state of physics at the time and served as a textbook for students of the subject. In Institutions de Physique, Émilie du Châtelet synthesized the works of a variety of physicists and incorporated her own original contributions, such as her ideas on energy conservation. Her book was notable for its clear and concise explanations of complex physical concepts, making it accessible to a wide audience.";
                            Debug.Log("Set to None");
                            footerDisplay.style.display = DisplayStyle.None;
                            Debug.Log("Is None");
                        }
                    }

                    if (hit.collider.gameObject.tag == "Luck") {
                        // Add specific text to display
                        if (infoRoot.style.display == DisplayStyle.None) {
                            scanRoot.style.display = DisplayStyle.None;
                            VisualElement infoImage = infoRoot.Q<VisualElement>("InfoImage");
                            Texture2D texture = Resources.Load<Texture2D>("InfoLuck");
                            infoImage.style.backgroundImage = texture;
                            infoRoot.style.display = DisplayStyle.Flex;
                            Label titleText = infoRoot.Q<Label>("InfoTitle");
                            titleText.text = "Discours sur \n le bonheur";
                            Label infoText = infoRoot.Q<Label>("InfoText");
                            infoText.text = "\"Discours sur le bonheur\" (Speech on Happiness) is a book by Émilie du Châtelet, published posthumously. The book describes the concept of happiness and how it is viewed in different philosophical traditions. She argues that happiness is a combination of pleasure, contentment and inner peace. She also emphasises the importance of knowledge and education and argues that these can help to achieve a deeper and lasting form of happiness. She also criticises the idea that happiness can only be achieved through material wealth. Instead, she argues that happiness is an internal matter and that it is not necessarily linked to external successes or material goods.";
                            Debug.Log("Set to None");
                            footerDisplay.style.display = DisplayStyle.None;
                            Debug.Log("Is None");
                        }
                    }
                }
            }
        }
        
    }

    private void closePanel() {
        infoRoot.style.display = DisplayStyle.None;
        scanRoot.style.display = DisplayStyle.Flex;
    }
}
