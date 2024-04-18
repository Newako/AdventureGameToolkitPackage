// STYLE SHEET EXAMPLE

// NAMING/CASING:
// - Use Pascal case (e.g. ExamplePlayerController, MaxHealth, etc.) unless noted otherwise.
// - Use camel case (e.g. examplePlayerController, maxHealth, etc.) for local/private variables, parameters.
// - Avoid snake case, kebab case, Hungarian notation
// - If you have a Monobehaviour in a file, the source file name must match. 

// FORMATTING:
// - use Allman (opening curly braces on a new line) style braces.
// - Use a single space before flow control conditions, e.g. while (x == y)
// - Avoid spaces inside brackets, e.g. x = dataArray[index]
// - Use a single space after a comma between function arguments.
// - Use vertical spacing (extra blank line) for visual separation. 

// COMMENTS:
// - Use the // comment to keep the explanation next to the logic.
// - Avoid Regions. They encourage large class sizes. Collapsed code is more difficult to read. 


// USING LINES:
// - Keep using lines at the top of your file.
// - Remove unsed lines.
using UnityEngine;
using System;

// NAMESPACES:
// - Pascal case, without special symbols or underscores.
// - Add using line at the top to avoid typing namespace repeatedly.
// - Create sub-namespaces with the dot (.) operator, e.g. MyApplication.GameFlow, MyApplication.AI, etc.
namespace StyleSheetExample
{

    // INTERFACES:
    // - Name interfaces with adjective phrases.
    // - Use the 'I' prefix.
    public interface IDamageable
    {
        string damageTypeName { get; }
        float damageValue { get; }

        // METHODS:
        // - Start a methods name with a verbs or verb phrases to show an action.
        // - Parameter names are camelCase.
        bool ApplyDamage(string description, float damage, int numberOfHits);
    }

    public interface IDamageable<T>
    {
        void Damage(T damageTaken);
    }

    // CLASSES or STRUCTS:
    // - Name them with nouns or noun phrases.
    // - Avoid prefixes.
    // - One Monobehaviour per file. If you have a Monobehaviour in a file, the source file name must match. 
    public class StyleExample : MonoBehaviour
    {

        // FIELDS: 
        // - Avoid special characters (backslashes, symbols, Unicode characters); these can interfere with command line tools.
        // - Use meaningful names. Make names searchable and pronounceable. Don’t abbreviate (unless it’s math).
        // - Add an underscore (_) in front of fields to differentiate from other variables.
        // - You can alternatively use more explicit prefixes: m_ = member variable, s_ = static, k_ = const

        private int _elapsedTimeInDays;

        // Use [SerializeField] attribute if you want to display a private field in Inspector.
        // Booleans ask a question that can be answered true or false.
        [SerializeField] private bool _isPlayerDead;

        // This groups data from the custom PlayerStats class in the Inspector.
        [SerializeField] private PlayerStats _stats;


        // PROPERTIES:
        // - Preferable to a public field.
        // - Pascal case, without special characters.
        // - Use the expression-bodied properties to shorten, but choose your preferred format.
        // - e.g. use expression-bodied for read-only properties but { get; set; } for everything else.
        // - Use the Auto-Implementated Property for a public property without a backing field.

        // the private backing field
        private int _maxHealth;

        // read-only, returns backing field
        public int MaxHealthReadOnly => _maxHealth;

        // equivalent to:
        // public int MaxHealth { get; private set; }

        // explicitly implementing getter and setter
        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        // write-only (not using backing field)
        public int Health { private get; set; }

        // write-only, without an explicit setter
        public void SetMaxHealth(int newMaxValue) => _maxHealth = newMaxValue;

        // auto-implemented property without backing field
        public string DescriptionName { get; set; } = "Fireball";


        // EVENTS:
        // - Name with a verb phrase.
        // - Present participle means "before" and past participle mean "after."
        // - Use System.Action delegate for most events (can take 0 to 16 parameters).
        // - Use the System.EventHandler; choose one and apply consistently.
        // - e.g. event/action = "OpeningDoor", event raising method = "OnDoorOpened", event handling method = "MySubject_DoorOpened"
   
        // event before
        public event Action OpeningDoor;

        // event after
        public event Action DoorOpened;     

        public event Action<int> PointsScored;
        public event Action<CustomEventArgs> ThingHappened;

        // These are event raising methods, e.g. OnDoorOpened, OnPointsScored, etc.
        public void OnDoorOpened()
        {
            DoorOpened?.Invoke();
        }

        public void OnPointsScored(int points)
        {
            PointsScored?.Invoke(points);
        }

        // This is a custom EventArg made from a struct.
        public struct CustomEventArgs
        {
            public int ObjectID { get; }
            public Color Color { get; }

            public CustomEventArgs(int objectId, Color color)
            {
                this.ObjectID = objectId;
                this.Color = color;
            }
        }


        // METHODS:
        // - Start a methods name with a verbs or verb phrases to show an action.
        // - Parameter names are camel case.

        // Methods start with a verb.
        public void SetInitialPosition(float x, float y, float z)
        {
            transform.position = new Vector3(x, y, z);
        }

        private void FormatExamples(int someExpression)
        {
            // VAR:
            // - Use var if it helps readability, especially with long type names.
            // - Avoid var if it makes the type ambiguous.
            var powerUps = new List<PlayerStats>();
            var dict = new Dictionary<string, List<GameObject>>();

            // BRACES: 
            // - avoid single-line statement entirely for debuggability.
            // - Keep braces in nested multi-line statements.

            // this is more debuggable. You can set a breakpoint on the clause.
            for (int i = 0; i < 100; i++)
            {
                DoSomething(i);
            }

            // Don't remove the braces here.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DoSomething(j);
                }
            }
        }

        private void DoSomething(int x)
        {
            // .. 
        }
    }

}