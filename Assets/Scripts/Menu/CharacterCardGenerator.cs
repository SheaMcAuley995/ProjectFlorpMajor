﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct CharacterData
{
    /// Display fields on the character card
    public RawImage videoFeedField;
    public Image genderField;
    public TextMeshProUGUI nameField, ageField, crimeField, sentenceField;

    /// Constructor for creating new character cards
    public CharacterData(RawImage _videoFeedField, Image _genderField, TextMeshProUGUI _nameField, TextMeshProUGUI _ageField, TextMeshProUGUI _crimeField, TextMeshProUGUI _sentenceField)
    {
        videoFeedField = _videoFeedField;
        genderField = _genderField;
        nameField = _nameField;
        ageField = _ageField;
        crimeField = _crimeField;
        sentenceField = _sentenceField;
    }
}

public class CharacterCardGenerator : MonoBehaviour
{
    public CharacterData data;
    public CharacterData[] savedCharacters;

    #region UI Selection Pool
    /// Image displays
    public RenderTexture videoFeed1, videoFeed2, videoFeed3, videoFeed4;
    public Sprite gender1, gender2, gender3, gender4;
    #endregion

    /// Lists
    List<RenderTexture> videoFeedList = new List<RenderTexture>();
    List<string> namesList = new List<string>();
    List<int> agesList = new List<int>();
    List<Sprite> gendersList = new List<Sprite>();
    List<string> crimesList = new List<string>();
    List<string> sentencesList = new List<string>();

    /// Random selection variables
    int videoFeedIndex, nameIndex, ageIndex, genderIndex, crimeIndex, sentenceIndex;

    int numOfSaves = 0;

    // Use this for initialization
    void Awake()
    {
        #region Generated List Content
        #region Video Feeds
        /// 5 portraits added to the list using the ListExtension class
        videoFeedList.AddMany(videoFeed1, videoFeed2, videoFeed3, videoFeed4);
        #endregion

        #region Names
        /// 90 names added to the list using the ListExtension class
        namesList.AddMany("Wroelk", "Gaohq", "Eisk", "Brozzyhm", "Struets",
            "Kruazek", "Strouerq", "Couz'lp", "Pheoblepsua", "Effyls",
            "Klecl", "Globbens", "Marohne", "Poesoth", "Treoffmm", "Knoziet",
            "Wruecrg", "Krougauhn", "Vreik'aelpheo", "Flybbuyhx", "Preodhxe",
            "Uaud", "Kmeib", "Qlyvp", "Zyohz", "Trahr", "Knuodromt", "Grizrq",
            "Rajts", "Veochy", "Suensul", "Vlaemsea", "Sloecals", "Caek",
            "Qlalm", "Briephuylloe", "Cleadyno", "Slachqo", "Tipseln",
            "Goupsiercua", "Kmuohnikx", "Sralfuerqa", "Giot", "Tuottihm",
            "Jiqulp", "Zrauwrets", "Pruyth", "Zrioth", "Uaxxiz", "Brykalz",
            "Vluh'", "Chype", "Heaphyll", "Alsokh", "Afyssae", "Kleamsuph",
            "Vluopuohxeo", "Klovvaelph", "Jeirfeomt", "Gruyphues", "Saurfauloe",
            "Zreaporc", "Bruypruyhq", "Strex", "Maurice the Space Cowboy", "Wuajm",
            "Vrauxxt", "Em", "Kriwrk", "Yk'lp", "Duttesk", "Wauqrhm", "Qleir'lt",
            "Qlats", "Plaem", "Uaclohs", "Ecle", "Nuama", "Faep", "Aloulmie",
            "Gnohnartue", "Prypihl", "Zythylph", "Buodhael", "Sukmilz", "Buylsyd",
            "Mith'ob Omega Supreme", "Corwaldron", "Zoriel", "EchoZoolu");
        #endregion

        #region Ages
        /// Ages 1 - 1,000 added to the list using the ListExtension class
        int maxAge = 1000;
        for (int age = 1; age < maxAge; age++)
        {
            agesList.AddMany(age);
        }
        #endregion

        #region Genders
        /// 4 gender icons added to the list (can add more) using the ListExtension class
        gendersList.AddMany(gender1, gender2, gender3, gender4);
        #endregion

        #region Crimes
        /// 65 crimes added to the list using the ListExtension class
        crimesList.AddMany("Astrolarsony", "Public inflorpication", "Space-whale poaching",
            "Not completing a dyson sphere", "Non-consensual evacuation of planets",
            "Space littering", "Something about opening an airlock in the wrong situation",
            "Serial cereal eating", "Accelerating the big crunch", "Public dabbing", 
            "Overpaying crewmembers", "Wearing the wrong shoe size", "Lollygagging",
            "Selling florponade without a permit", "Owning too many cats",
            "Owning too few cats", "Sneezing loudly", "Leaving the water running",
            "Spilling the florp", "Failure to properly shuffle cards", "Drawing on the table",
            "Jigglegaffing within 30 parsecs of the big bang", "Incorrectly using the word 'blockchain'", 
            "Unsanctioned rapid unscheduled disassembly", "Unlicensed terraforming", "Unsafe hyperlane change", 
            "Calling yourself a space pirate", "Drinking the florp", "Panicking at the disco",
            "Couldn't handle the truth", "Failing to study history... and then repeating it",
            "Launching a spacecraft out of the solar system with a map to the home planet on it",
            "Failed to provide more cowbell", "Failed to construct additional pylons",
            "Fought for their right to party", "Star arson", "Crashing the LAN party",
            "Removed the watermark", "Coloring outside the lines", "Sneezed without covering their mouth",
            "Left someone on 'read'", "Eating all of the cookies", "Novel reading",
            "Boring when inflorpicated", "Obsession with anime", "Failing a Turing test while biological",
            "Feebleness of intellect", "Video game addiction", "Using only 10% of the brain",
            "Use of imperial units instead of metric", "Piloting under the influence of spice",
            "Noise ordinance violation: playing music too loudly in space", "Poor taste in art",
            "Untidy computer desktop", "Timeline destabilization",
            "Desynchronizing the phase cycles of a quantum entanglement tunneler",
            "Unsanctioned alteration of a moon's orbit", "Possession of florp with intent to redistribute",
            "Hitting all of the buttons on a space elevator",
            "Speeding - going warp 80 in a warp 65 zone", "Public indecency and indecent publicity",
            "Traumatizing a Class 0 Civilization with a fake alien invasion",
            "Saw someone sneeze... and didn't say 'bless you'", "Florp-juggling without a license",
            "Engaging in online propaganda");
        #endregion

        #region Sentences
        /// 35 sentences added to the list using the ListExtension class
        sentencesList.AddMany("1e+08 quantum galactic cycles cleaning the Aether",
            "500 years in the spice mines of Druffel", "Food for the broodmother",
            "Community service", "Rehabilitation classes", "Extra math homework",
            "Fined 25 million aliencoin", "Infinite suffering in a cyclical time loop",
            "Minus 50 DKP", "Doesn't have to go home, but they can't stay here",
            "Handcuffed to their clone",
            "To be exposed to a vacuum for approximately 20.4111111176 seconds",
            "THE CLAW", "Something really, really bad", "Has to wear wet socks",
            "To be used as a test subject", "No wifi",
            "Has to do the Druffel run in less than 11 parsecs",
            "Must memorize the SpaceTunes terms and conditions",
            "Internet access restricted to 56k modem",
            "Has to program an operating system entirely in binary",
            "10 years of hard labor as a trash compactor inspector",
            "To be marooned on a desert planet with two suns and two idiotic droids",
            "To be used to plug a hole the size of a dinner plate in the airlock",
            "Must run a barefoot marathon on a path strewn with legos",
            "Disassembly by nanobots", "Involuntary organ donation",
            "Brain to be removed from body and inserted into a manufacturing robot",
            "Body to be donated to science prior to death",
            "Atmospheric reentry without a heat shield",
            "To be replaced by a clone and forced to watch it live out it's life",
            "To have 50% of all good memories removed",
            "Banished to a wretched hive of scum and villainy",
            "To be given laxatives and pushed into space so that their last act will be to boldly go where no one has gone before",
            "To be stranded on an ocean planet near the event horizon of a black hole");
        #endregion
        #endregion
    }

    /// Generates a new prisoner card
    public void GenerateCard()
    {
        /// Utilizes the constructor to create new data for the character card
        CharacterData newCharacter = new CharacterData(data.videoFeedField, data.genderField, data.nameField, data.ageField, data.crimeField, data.sentenceField);

        /// TODO: Cache these later for some of that sweet juicy #efficiency
        #region Random Selection Determiner
        videoFeedIndex = Random.Range(0, 4);
        nameIndex = Random.Range(0, 90);
        ageIndex = Random.Range(18, 60);
        //DetermineAgeBias(); My frens don't like it so I'm killing it until I make cases for each species. :'( 
        genderIndex = Random.Range(0, 4);
        crimeIndex = Random.Range(0, 65);
        sentenceIndex = Random.Range(0, 35);
        #endregion

        #region Character Card Display Setter
        newCharacter.videoFeedField.texture = videoFeedList[videoFeedIndex]; /// Sets the character card's video feed to the randomly selected feed.
        newCharacter.nameField.text = namesList[nameIndex]; /// Sets the character card's name to the randomly selected portrait.
        newCharacter.ageField.text = agesList[ageIndex].ToString(); /// Sets the character card's age to the pseudo-randomly selected age.
        newCharacter.genderField.sprite = gendersList[genderIndex]; /// Sets the character card's gender to the randomly selected gender.
        newCharacter.crimeField.text = crimesList[crimeIndex]; /// Sets the character card's convicted crime to the randomly selected crime.
        newCharacter.sentenceField.text = sentencesList[sentenceIndex]; /// Sets the character card's sentence to the randomly selected sentence.
        #endregion

        savedCharacters[numOfSaves] = newCharacter;
        numOfSaves++;
    }

    public void ReloadPreviousCard()
    {
        CharacterData prevCharacter = new CharacterData(data.videoFeedField, data.genderField, data.nameField, data.ageField, data.crimeField, data.sentenceField);

        numOfSaves--;

        prevCharacter = savedCharacters[numOfSaves];
    }
}
