using System;
using self;

public class vessel
{
    public string Name { get; set; }
    public int Shield { get; set; }
    public int Armor { get; set; }
    public int Hull { get; set; }
    public bool IsDestroyed { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public void TakeDamage(int amount)
    {
        if (!IsDestroyed)
        {
            if (Shield > 0)
            {
                Shield -= amount;
                if (Shield < 0)
                {
                    amount = Math.Abs(Shield);
                    Shield = 0;
                }
                else
                {
                    amount = 0;
                }
            }
            if (amount > 0 && Armor > 0)
            {
                Armor -= amount;
                if (Armor < 0)
                {
                    amount = Math.Abs(Armor);
                    Armor = 0;
                }
                else
                {
                    amount = 0;
                }
            }
            if (amount > 0)
            {
                Hull -= amount;
                if (Hull <= 0)
                {
                    IsDestroyed = true;
                    Console.WriteLine($"{Name} has been destroyed!");
                }
            }
        }
    }

    public void TakeDamage(int amount, bool ignoreShield)
    {
        if (!IsDestroyed)
        {
            if (ignoreShield)
            {
                if (amount > 0 && Armor > 0)
                {
                    Armor -= amount;
                    if (Armor < 0)
                    {
                        amount = Math.Abs(Armor);
                        Armor = 0;
                    }
                    else
                    {
                        amount = 0;
                    }
                }
            }
            else
            {
                TakeDamage(amount);
            }
        }
    }
}

public class SensorData
{
    public string Name { get; set; }
    public int Shield { get; set; }
    public int Armor { get; set; }
    public int Hull { get; set; }
    public bool IsDestroyed { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Weapons { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int MaxSpeed { get; set; }
    public int FramesPerSecondSquared { get; set; } // Added property for frames per second squared
    public double GasLevitationForce { get; set; } // Added property for gas levitation force
    public int Thrust { get; set; } // Added property for thrust
}

public class Program
{
    public static void Main(string[] args)
    {
        vessel vessel1 = new vessel { Name = "vessel1", Shield = 2 ^ 1000, Armor = 2 ^ 800, Hull = 2 ^ 1500, PositionX = 0, PositionY = 0, Length = 72, Width = 8, Height = 13 };
        vessel vessel2 = new vessel { Name = "vessel2", Shield = 2 ^ 1200, Armor = 2 ^ 1000, Hull = 2 ^ 1300, PositionX = 100, PositionY = 100, Length = 72, Width = 8, Height = 13 };

        SensorData self = new SensorData { Name = "self", Shield = 0, Armor = 0, Hull = 0, PositionX = 0, PositionY = 0, Weapons = 10, Length = 72, Width = 8, Height = 13, MaxSpeed = 10, GasLevitationForce = 9.8, Thrust = 100 }; // Added Thrust property

        while (!vessel1.IsDestroyed && !vessel2.IsDestroyed)
        {
            // Simulate attack from vessel1 to vessel2
            int damageToVessel2 = 200; // damage amount
            vessel2.TakeDamage(damageToVessel2);

            // Simulate attack from vessel2 to vessel1
            int damageToVessel1 = 250; // damage amount
            vessel1.TakeDamage(damageToVessel1);

            // Observe attack from vessel1 to vessel2
            Console.WriteLine($"{vessel1.Name} attacks {vessel2.Name} for {damageToVessel2} damage");
            Console.WriteLine($"Speed of {vessel1.Name}: {CalculateSpeed(vessel1)}");
            Console.WriteLine($"Speed of {vessel2.Name}: {CalculateSpeed(vessel2)}");

            // Observe attack from vessel2 to vessel1
            Console.WriteLine($"{vessel2.Name} attacks {vessel1.Name} for {damageToVessel1} damage");
            Console.WriteLine($"Speed of {vessel1.Name}: {CalculateSpeed(vessel1)}");
            Console.WriteLine($"Speed of {vessel2.Name}: {CalculateSpeed(vessel2)}");

            // Simulate other actions, such as repairs, reinforcements, etc.

            // Update vessel positions
            vessel1.PositionX += 10;
            vessel1.PositionY += 10;
            vessel2.PositionX -= 5;
            vessel2.PositionY -= 5;
        }

        Console.WriteLine("Check Data");
    }

    public static double CalculateSpeed(vessel vessel)
    {
        double speed = Math.Sqrt((vessel.PositionX * vessel.PositionX) + (vessel.PositionY * vessel.PositionY)) / vessel.FramesPerSecondSquared;
        return speed;
    }
}

public static string GetVesselVisual(vessel vessel)
{
    string visual = "";
    visual += $"Name: {vessel.Name}\n";
    visual += $"Shield: {vessel.Shield}\n";
    visual += $"Armor: {vessel.Armor}\n";
    visual += $"Hull: {vessel.Hull}\n";
    visual += $"IsDestroyed: {vessel.IsDestroyed}\n";
    visual += $"PositionX: {vessel.PositionX}\n";
    visual += $"PositionY: {vessel.PositionY}\n";
    visual += $"Length: {vessel.Length}\n";
    visual += $"Width: {vessel.Width}\n";
    visual += $"Height: {vessel.Height}\n";
    return visual;
}

public class Program
{
    public static void Main(string[] args)
    {
        vessel vessel1 = new vessel { Name = "vessel1", Shield = 2 ^ 1000, Armor = 2 ^ 800, Hull = 2 ^ 1500, PositionX = 0, PositionY = 0 };
        vessel vessel2 = new vessel { Name = "vessel2", Shield = 2 ^ 1200, Armor = 2 ^ 1000, Hull = 2 ^ 1300, PositionX = 100, PositionY = 100 };

        while (!vessel1.IsDestroyed && !vessel2.IsDestroyed)
        {
            // Simulate attack from vessel1 to vessel2
            int damageTovessel2 = 200; //  damage amount
            vessel2.TakeDamage(damageTovessel2);

            // Simulate attack from vessel2 to vessel1
            int damageTovessel1 = 250; //  damage amount
            vessel1.TakeDamage(damageTovessel1);

            // Observe attack from vessel1 to vessel2
            Console.WriteLine($"{vessel1.Name} attacks {vessel2.Name} for {damageTovessel2} damage");

            // Observe attack from vessel2 to vessel1
            Console.WriteLine($"{vessel2.Name} attacks {vessel1.Name} for {damageTovessel1} damage");

            // Simulate other actions, such as repairs, reinforcements, etc.

            public static void Main(string[] args)
            {
                vessel vessel1 = new vessel { Name = "vessel1", Shield = 2 ^ 1000, Armor = 2 ^ 800, Hull = 2 ^ 1500, PositionX = 0, PositionY = 0 };
                using System;
                using self;

                public class vessel
    {
        public string Name { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Hull { get; set; }
        public bool IsDestroyed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public void TakeDamage(int amount)
        {
            if (!IsDestroyed)
            {
                if (Shield > 0)
                {
                    Shield -= amount;
                    if (Shield < 0)
                    {
                        amount = Math.Abs(Shield);
                        Shield = 0;
                    }
                    else
                    {
                        amount = 0;
                    }
                }
                if (amount > 0 && Armor > 0)
                {
                    Armor -= amount;
                    if (Armor < 0)
                    {
                        amount = Math.Abs(Armor);
                        Armor = 0;
                    }
                    else
                    {
                        amount = 0;
                    }
                }
                if (amount > 0)
                {
                    Hull -= amount;
                    if (Hull <= 0)
                    {
                        IsDestroyed = true;
                        Console.WriteLine($"{Name} has been destroyed!");
                    }
                }
            }
        }

        public void TakeDamage(int amount, bool ignoreShield)
        {
            if (!IsDestroyed)
            {
                if (ignoreShield)
                {
                    if (amount > 0 && Armor > 0)
                    {
                        Armor -= amount;
                        if (Armor < 0)
                        {
                            amount = Math.Abs(Armor);
                            Armor = 0;
                        }
                        else
                        {
                            amount = 0;
                        }
                    }
                }
                else
                {
                    TakeDamage(amount);
                }
            }
        }
    }

    class SensorData
    {

        public string Name { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Hull { get; set; }
        public bool IsDestroyed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Weapons { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MaxSpeed { get; set; }
        public int FramesPerSecondSquared { get; set; } // Added property for frames per second squared

        public bool IsNotVessel1OrVessel2();
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            vessel vessel1 = new vessel { Name = "vessel1", Shield = 2 ^ 1000, Armor = 2 ^ 800, Hull = 2 ^ 1500, PositionX = 0, PositionY = 0, Length = 72, Width = 8, Height = 13 };
            vessel vessel2 = new vessel { Name = "vessel2", Shield = 2 ^ 1200, Armor = 2 ^ 1000, Hull = 2 ^ 1300, PositionX = 100, PositionY = 100, Length = 72, Width = 8, Height = 13 };

            SensorData self = new SensorData { Name = "self", Shield = 0, Armor = 0, Hull = 0, PositionX = 0, PositionY = 0, Weapons = 10, Length = 72, Width = 8, Height = 13, MaxSpeed = 10 }; // Added MaxSpeed property

            while (!vessel1.IsDestroyed && !vessel2.IsDestroyed)
            {
                // Simulate attack from vessel1 to vessel2
                int damageToVessel2 = 200; // damage amount
                vessel2.TakeDamage(damageToVessel2);

                // Simulate attack from vessel2 to vessel1
                int damageToVessel1 = 250; // damage amount
                vessel1.TakeDamage(damageToVessel1);

                // Observe attack from vessel1 to vessel2
                // Observe attack from vessel1 to vessel2
                Console.WriteLine($"{vessel1.Name} attacks {vessel2.Name} for {damageToVessel2} damage");
                Console.WriteLine($"Speed of {vessel1.Name}: {CalculateSpeed(vessel1)}");
                Console.WriteLine($"Speed of {vessel2.Name}: {CalculateSpeed(vessel2)}");

                // Observe attack from vessel2 to vessel1
                Console.WriteLine($"{vessel2.Name} attacks {vessel1.Name} for {damageToVessel1} damage");
                Console.WriteLine($"Speed of {vessel1.Name}: {CalculateSpeed(vessel1)}");
                Console.WriteLine($"Speed of {vessel2.Name}: {CalculateSpeed(vessel2)}");
                Console.WriteLine($"{vessel1.Name} attacks {vessel2.Name} for {damageToVessel2} damage");

                // Observe attack from vessel2 to vessel1
                Console.WriteLine($"{vessel2.Name} attacks {vessel1.Name} for {damageToVessel1} damage");

                // Simulate other actions, such as repairs, reinforcements, etc.

                // Update vessel positions
                vessel1.PositionX += 10;
                vessel1.PositionY += 10;
                vessel2.PositionX -= 5;
                vessel2.PositionY -= 5;
            }

            Console.WriteLine("Check Data");
        }
    }

    public static string GetVesselVisual(vessel vessel)
    {
        string visual = "";
        visual += $"Name: {vessel.Name}\n";
        visual += $"Shield: {vessel.Shield}\n";
        visual += $"Armor: {vessel.Armor}\n";
        visual += $"Hull: {vessel.Hull}\n";
        visual += $"IsDestroyed: {vessel.IsDestroyed}\n";
        visual += $"PositionX: {vessel.PositionX}\n";
        visual += $"PositionY: {vessel.PositionY}\n";
        visual += $"Length: {vessel.Length}\n";
        visual += $"Width: {vessel.Width}\n";
        visual += $"Height: {vessel.Height}\n";
        return visual;
    }
                vessel vessel2 = new vessel { Name = "vessel2", Shield = 2 ^ 1200, Armor = 2 ^ 1000, Hull = 2 ^ 1300, PositionX = 100, PositionY = 100 };

                while (!vessel1.IsDestroyed && !vessel2.IsDestroyed)
                {
                    // Simulate attack from vessel1 to vessel2
                    int damageToVessel2 = 200; // damage amount
                    vessel2.TakeDamage(damageToVessel2);

                    // Simulate attack from vessel2 to vessel1
                    int damageToVessel1 = 250; // damage amount
                    vessel1.TakeDamage(damageToVessel1);

                    // Observe attack from vessel1 to vessel2
                    Console.WriteLine($"{vessel1.Name} attacks {vessel2.Name} for {damageToVessel2} damage");
                    Console.WriteLine("Vessel1: " + GetVesselVisual(vessel1));
                    Console.WriteLine("Vessel2: " + GetVesselVisual(vessel2));

                    // Observe attack from vessel2 to vessel1
                    Console.WriteLine($"{vessel2.Name} attacks {vessel1.Name} for {damageToVessel1} damage");
                    Console.WriteLine("Vessel1: " + GetVesselVisual(vessel1));
                    Console.WriteLine("Vessel2: " + GetVesselVisual(vessel2));

                    // Simulate other actions, such as repairs, reinforcements, etc.

                    // Update vessel positions
                    vessel1.PositionX += 10;
                    vessel1.PositionY += 10;
                    vessel2.PositionX -= 5;
                    vessel2.PositionY -= 5;
                }

                Console.WriteLine("Check Data");
            }

            using System;

            public class vessel
    {
        public string Name { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Hull { get; set; }
        public bool IsDestroyed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public void TakeDamage(int amount)
        {
            if (!IsDestroyed)
            {
                if (Shield > 0)
                {
                    Shield -= amount;
                    if (Shield < 0)
                    {
                        amount = Math.Abs(Shield);
                        Shield = 0;
                    }
                    else
                    {
                        amount = 0;
                    }
                }
                if (amount > 0 && Armor > 0)
                {
                    Armor -= amount;
                    if (Armor < 0)
                    {
                        amount = Math.Abs(Armor);
                        Armor = 0;
                    }
                    else
                    {
                        amount = 0;
                    }
                }
                if (amount > 0)
                {
                    Hull -= amount;
                    if (Hull <= 0)
                    {
                        IsDestroyed = true;
                        Console.WriteLine($"{Name} has been destroyed!");
                    }
                }
            }
        }

        public void TakeDamage(int amount, bool ignoreShield)
        {
            if (!IsDestroyed)
            {
                if (ignoreShield)
                {
                    if (amount > 0 && Armor > 0)
                    {
                        Armor -= amount;
                        if (Armor < 0)
                        {
                            amount = Math.Abs(Armor);
                            Armor = 0;
                        }
                        else
                        {
                            amount = 0;
                        }
                    }
                }
                else
                {
                    TakeDamage(amount);
                }
            }
        }
    }

    public class SensorData
    {
        public string Name { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int Hull { get; set; }
        public bool IsDestroyed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            vessel vessel1 = new vessel { Name = "vessel1", Shield = 2 ^ 1000, Armor = 2 ^ 800, Hull = 2 ^ 1500, PositionX = 0, PositionY = 0 };
            vessel vessel2 = new vessel { Name = "vessel2", Shield = 2 ^ 1200, Armor = 2 ^ 1000, Hull = 2 ^ 1300, PositionX = 100, PositionY = 100 };

            while (!vessel1.IsDestroyed && !vessel2.IsDestroyed)
            {
                // Simulate imaginary attack from vessel1 to vessel2
                int damageToVessel2 = 200; // damage amount
                vessel2.TakeDamage(damageToVessel2);

                // Simulate imaginary attack from vessel2 to vessel1
                int damageToVessel1 = 250; // damage amount
                vessel1.TakeDamage(damageToVessel1);

                // Observe imaginary attack from vessel1 to vessel2
                Console.WriteLine($"{vessel1.Name} attacks {vessel2.Name} for {damageToVessel2} damage");

                // Observe imaginary attack from vessel2 to vessel1
                Console.WriteLine($"{vessel2.Name} attacks {vessel1.Name} for {damageToVessel1} damage");

                // Simulate other imaginary actions, such as repairs, reinforcements, etc.

                // Update vessel positions
                vessel1.PositionX += 10;
                vessel1.PositionY += 10;
                vessel2.PositionX -= 5;
                vessel2.PositionY -= 5;
            }

            Console.WriteLine("Check Data");
        }
    }
    public class Motherboard
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SocketType { get; set; }
        public int MaxMemory { get; set; }
        public int MaxStorage { get; set; }
    }

    public class HardDriveDisk
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string InterfaceType { get; set; }
    }

    public class CPUMicrochip
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SocketType { get; set; }
        public int Cores { get; set; }
        public int ClockSpeed { get; set; }
    }

    public static string GetVesselVisual(vessel vessel)
    {
        string visual = "";
        visual += $"Name: {vessel.Name}\n";
        visual += $"Shield: {vessel.Shield}\n";
        visual += $"Armor: {vessel.Armor}\n";
        visual += $"Hull: {vessel.Hull}\n";
        visual += $"IsDestroyed: {vessel.IsDestroyed}\n";
        visual += $"PositionX: {vessel.PositionX}\n";
        visual += $"PositionY: {vessel.PositionY}\n";
        return visual;
    }
            // Update vessel positions
            vessel1.PositionX += 10;
            vessel1.PositionY += 10;
            vessel2.PositionX -= 5;
            vessel2.PositionY -= 5;
        }

        Console.WriteLine("Check Data");
    }
}
