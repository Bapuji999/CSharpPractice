namespace BasicsAndOOPsPart2Practice
{
    class EncapsulationExample
    {
        private string name; // Private field

        public string Name // Property with get and set accessors
        {
            private get { return name; } // Getter
            set { name = value; } // Setter
        }
        private int x { get; set; } //auto-implemented property
    }
    class EncapsulationExample2
    {
        public void Example()
        {
            EncapsulationExample encapsulationExample = new EncapsulationExample();
            encapsulationExample.Name = "abc";
            //var a = encapsulationExample.Name;
        }
    }
}
//Auto - implemented properties have default values for their types (e.g., 0 for int, null for reference types)
//because the compiler initializes the generated backing field.

//Conventional properties don't have default values for their backing fields.
//You need to initialize the backing field in the class constructor or during declaration
//if you want to provide a default value.
