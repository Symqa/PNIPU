. . . .. . . ..
typedef STRUCT
{
char name[40];
char post[40];
float rate;
}EMPLOYEE;
void main()
{
    FILE* f;	// указатель связанный с файлом
    EMPLOYEE e;	// переменная
    EMPLOYEE mas[10]	//массив
        //открываем файл
        if ((f = fopen("f.dat", "wb") == NULL) exit(1); // если при от-крытии файла возникает 
            //ошибка, то выходим из функции
            int i;
            for (i = 1; i <= 10;i++)
            {
                //формируем запись е
                printf("name="); scanf("%s", &e.name);
                printf("post="); scanf("%s", &e.post);
                printf("rate="); scanf("%f", e.rate);
                // записываем запись е в файл
                    fwrite(&e, sizeof(EMPLOYEE), 1, f);
                    if (ferror(f) == NULL) exit(2);
            }
    fclose(f);
    //чтение записей из файла
    if ((f = fopen("f.dat", "rb") == NULL) exit(3); // если при от-крытии файла возникает 
        //ошибка, то выходим из функции
        i = 0;
        while (!feof(f) && i <= 10)
        {
            fread(&mas[i], sizeof(EMPLOYEE), 1, f);
            i++;
        }
    fclose(f);
}
