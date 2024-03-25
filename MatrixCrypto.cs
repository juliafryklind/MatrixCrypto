using System;
//skapa två matriser
int[,] matA= new int[2, 2]; //förstmat[0,0]matrisen - default
int[,] matB = new int[2, 2]; //andrmat[0,0]matrisen - default

int det = 0;
bool isRunning = true;
while (isRunning)
{
  //slumpa fram värden
        int a = Random.Shared.Next(1, 100);
        int b = Random.Shared.Next(1, 100);
        int c =  Random.Shared.Next(1, 100);
        int d = Random.Shared.Next(1, 100);
    det = a*d-b*c;

    if (det== 1) {
        matA[0, 0] = a;
        matA[0, 1] = b;
        matA[1, 0] = c;
        matA[1, 1] = d;

        matB[0, 0] = d / det;
        matB[0, 1] = -b / det;
        matB[1, 0] = -c / det;
        matB[1, 1] = a / det;

        isRunning = false; 
    }

}



Console.WriteLine("Skriv in ditt hemliga meddelande...");
string userdata = Console.ReadLine(); //användardata - default

if (userdata.Length % 2 != 0)
{
    userdata = userdata + " ";

}

char[] rawChar = userdata.ToCharArray(); //en "rå" array, delar upp userdata till flera

int[] rawInt = new int[rawChar.Length]; //deklarerar rawInt som variabel

for (int i = 0; i < rawChar.Length; i++) //omvandlar varje element i rawChar till int och tilldelar till rawInt
{
    rawInt[i] = Convert.ToInt32(rawChar[i]);

}

int[,] intArray = new int[2, (rawInt.Length / 2)]; //en array som kommer innehålla alla nummer vi ska kryptera
int[,] encryptArray = new int[2, rawInt.Length / 2];
int[,] decryptArray = new int[2, rawInt.Length / 2];

AssingnValue();
Console.WriteLine();
Encrypt();
Decrypt();
PrintMatrix(encryptArray);
Console.WriteLine();
printLetters(decryptArray);
Console.WriteLine();
void AssingnValue()
{


    for (int i = 0; i < intArray.GetLength(0); i++) //i<2

    {
        for (int j = 0; j < intArray.GetLength(1); j++) //j<4
        {
            intArray[i, j] = rawInt[j + (i * (rawInt.Length / 2))];
        }

    }
}

void PrintMatrix(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++) //i<2

    {
        for (int j = 0; j < arr.GetLength(1); j++) //j<4
        {

            Console.Write(arr[i, j]);

        }

    }
}
void Encrypt()
{

    for (int i = 0; i < intArray.GetLength(0); i++) //i är x
    {

        for (int j = 0; j < intArray.GetLength(1); j++) //j är kolumn
        {
            encryptArray[i, j] = matA[i, 0] * intArray[0, j] + matA[i, 1] * intArray[1, j];


        }



    }
}

void Decrypt()
{
    for (int i = 0; i < encryptArray.GetLength(0); i++) //i är x
    {

        for (int j = 0; j < encryptArray.GetLength(1); j++) //j är kolumn
        {
            decryptArray[i, j] = matB[i, 0] * encryptArray[0, j] + matB[i, 1] * encryptArray[1, j];



        }

    }
}
void printLetters(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++) //i<2

    {
        for (int j = 0; j < arr.GetLength(1); j++) //j<4
        {


            int number = arr[i, j];
            char letter = (char)number;
            Console.Write(letter);

        }

    }
}

