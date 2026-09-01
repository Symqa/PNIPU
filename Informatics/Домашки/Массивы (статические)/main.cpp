#include <iostream>
#include <clocale>
#include <conio.h>
#include <stdio.h>

using namespace std;

void first() {
	cout << "1: " << endl;
	const int size = 5;
	int max, index, count = 1, arr[size];

	for (int& i : arr) {
		cin >> i;
	}
	max = arr[0];

	for (int i = 0; i < size; i++) {
		if (arr[i] == max) {
			count++;
			index = i;
		}
		else if (arr[i] > max) {
			max = arr[i];
			count = 1;
			index = i;
		}
	}

	// Вывод массива
	for (int& i : arr) {
		cout << i << ' ';
	}
	cout << endl << endl;

	// Вывод переменных
	cout << "Максимальный элемент: " << max << endl << "Количество: " << count << endl << "Индекс последнего: " << index << endl << "Номер последнего: " << ++index << endl << endl;


}

void second() {
	cout << "2:" << endl;
	const int size = 5;
	int arr[size];

	for (int& i : arr) {
		cin >> i;
	}
	cout << "Исходный массив: ";

	for (int& i : arr) {
		cout << i << ' ';
	}
	cout << endl;

	for (int i = 1; i <= size / 2; i++) {

		arr[size - i] += arr[i - 1];
		arr[i - 1] = arr[size - i] - arr[i - 1];
		arr[size - i] -= arr[i - 1];


	}
	cout << "Перевернутый массив: ";
	for (int& i : arr) {
		cout << i << ' ';
	}
}

int main() {
	setlocale(LC_ALL, "ru");
	first();
	second();
	_getch();
	return 0;
}