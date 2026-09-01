#include <iostream>
#include <stdlib.h>
#include <clocale>

using namespace std;

void print_arr(int* arr, const int &N) {
    cout << "Результат: ";
    for (int i = 0; i < N; i++) {
        cout << arr[i] << ' ';
    }
    cout << endl;
}

void generate_arr(int* arr, const int& N) {
    for (int i = 0; i < N; i++) {
        arr[i] = rand() % 100 - 50;
    }
    cout << "Исходный массив: ";
    for (int i = 0; i < N; i++) {
        cout << arr[i] << ' ';
    }
    cout << endl;
}

void insert_sort(int* arr, const int& N) {
    cout << endl;
    cout << "Метод вставки: " << endl;
    generate_arr(arr, N);
    for (int i = 1; i < N; ++i) {
        int temp = arr[i];
        int j = i - 1;
        while (j >= 0 && arr[j] > temp) {
            arr[j + 1] = arr[j];
            --j;
        }
        arr[j + 1] = temp;
    }
    print_arr(arr, N);
}

void selection_sort(int* arr, const int& N)
{   
    cout << endl;
    cout << "Метод выбора: " << endl;
    generate_arr(arr, N);
    for (int i = 0; i < N - 1; i++)
    {
        int min = i;
        for (int j = i + 1; j < N; j++)
            if (arr[min] > arr[j])
                min = j;
        if (min != i)
        {
            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
    }
    print_arr(arr, N);
}

void bubble_sort(int* arr, const int& N)
{
    cout << endl;
    cout << "Метод пузырька: " << endl;
    generate_arr(arr, N);
    for (int i = 0; i < N; i++)
        for (int j = 0; j < N - i - 1; j++)
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
    print_arr(arr, N);
}


int main() {
    setlocale(LC_ALL, "ru");
    int j;
    const int N = 5;
    int arr[N];
    
    insert_sort(arr, N);
    selection_sort(arr, N);
    bubble_sort(arr, N);
    
    cin >> j;
    

    return 0;
}