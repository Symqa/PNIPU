class CountException(Exception):
    pass

class NotInUException(Exception):
    pass

def main():
    # U = A = B = C = D = E = []
    U = input_U()
    print(U)
    A = [2, 3]
    B = [3, 4]
    C = [4, 5]
    D = [1, 5]
    E = [2, 5]


    intersection(A, B)
    intersection(A, C)
    intersection(C, E)
    multitude(1, A)
    multitude(2, A)
    entry(A, U)
    entry(A, B)


# ==== 1. Заполнение U ====
def input_U():
    try:
        U = []
        for num in input("Введите элементы универсального множества U (целочисленные через пробел, без повторов):").split():
            if int(num) not in U:
                U.append(int(num))
            else:
                raise CountException(num)
        return U
    except ValueError:
        print("Ошибка: Ввод должен быть целочисленным.")
        exit()
    except CountException as exception:
        print(f"Ошибка: элемент {exception} используется в универсальном множестве два или более раз.")
        exit()


# === 2.1 Заполнение множества вручную ====
def input_multitudes_manually(multitude_name, U):
    try:
        multitude = []
        for num in input(f"Введите элементы множества {multitude_name} (целочисленные через пробел)").split():
            if int(num) not in multitude:
                if int(num) in U:
                    multitude.append(int(num))
                else:
                    raise NotInUException(num)
            else:
                raise CountException(num)
        return multitude
    except ValueError:
        print("Ошибка: Ввод должен быть целочисленным.")
        exit()
    except CountException as exception:
        print(f"Ошибка: элемент {exception} используется в множестве {multitude_name} два или более раз.")
        exit()
    except NotInUException as exception:
        print(f"Ошибка: элемент {exception} не найден в множестве U.")
        exit()


# === 2.2 Заполнение множества через генератор ====
def input_multitude_random(multitude_name, U):
    multitude = []
    

# ==== 3. ОПЕРАЦИИ ==== 
# пересечение
def intersection(first, second):
    res = []
    for num in first:
        if num in second:
            res.append(num)

    print(f"Пересечение множеств {first}, {second} : {res}")

# объединение
def unification(first, second):
    res = []
    for num in first:
        res.append(num)
        if num not in second:
            res.append(num)

    print(f"Объединение множеств {first}, {second} : {res}\n")


# Разность
def difference(first, second):
    res = []
    for num in first:
        if num not in second:
            res.append(num)
    print(f"Разность множеств {first}, {second} : {res}\n")


# Симметричная разность
def symmetric_difference(first, second):
    res = []
    for num in first:
        if num not in second:
            res.append(num)
    for num in second:
        if num not in first:
            res.append(num)
    print(f"Cимметричная разность множеств {first}, {second} : {res}\n")


# Дополнение
def addition(first, U):
    res = []
    for num in U:
        if num not in first:
            res.append(num)
    print(f"Дополнение множества {first} (универсальное множество: {U}) : {res}\n")



# ===== 4. Принадлежит ли множеству ========
def multitude(element, multitude):
    print(f"Элемент {element} принадлежит множеству {multitude} : {element in multitude}") 


# ==== 5. Входит ли одно в другое ==========
def entry(first, second):
    isEntry = True
    for i in range(len(first)):
        if (first[i] not in second):
            isEntry = False
    print(f"Множество {first} принадлежит множеству {second} : {isEntry}") 
    
        

            
     


if __name__ == '__main__':
    main()