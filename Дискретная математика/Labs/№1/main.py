import random

class CountException(Exception):
    pass


class NotInUException(Exception):
    pass


class Multitude:
    def __init__(self, name: str, index: int):
        self.name = name
        self.index = index


def main():
    U = []
    multitudes = [[], [], [], [], []] # A, B, C, D, E
    while True:
        choice = run_menu('\nМеню:\n' \
                        '1. Задать универсальное множество U\n' \
                        '2. Задать множества (A, B, C, D, E)\n' \
                        '3. Выполнение операций над множествами\n' \
                        '4. Проверить принадлежность элемента множеству\n' \
                        '5. Проверить входит ли одно подмножество в другое\n' \
                        '6. Текущее состояние множеств\n' \
                        '7. Выход',
                        7)
        match(choice):
            case 1:
                U = input_U()
            case 2:
                multitude = get_multitude_by_user_input()
                method_choice = run_menu('Выберите способ заполнения множества:\n' \
                                '1. Вручную\n' \
                                '2. С помощью генератора чисел',
                                2)
                match(method_choice):
                    case 1:
                        multitudes[multitude.index] = input_multitudes_manually(multitude.name, U)
                    case 2:
                        multitudes[multitude.index] = input_multitude_random(multitude.name, U)
            case 3:
                multitude_first = get_multitude_by_user_input('Выберите первый операнд (множество):')
                if len(multitudes[multitude_first.index]) == 0:
                    print(f'Ошибка: множество {multitude_first.name} пустое.')
                    continue
                operation_choice = run_menu('\nВыберите операцию:\n' \
                                  '1. Пересечение\n' \
                                  '2. Объединение\n' \
                                  '3. Разность\n' \
                                  '4. Симметричная разность\n' \
                                  '5. Дополнение',
                                  5)
                if operation_choice != 5:
                    multitude_second = get_multitude_by_user_input('Выберите второй операнд (множество):')
                    if len(multitudes[multitude_second.index]) == 0:
                                        print(f'Ошибка: множество {multitude_second.name} пустое.')
                                        continue
                match(operation_choice):
                    # intersection, unification, difference, symmetric_difference, addition
                    case 1:
                        intersection(multitudes[multitude_first.index], multitudes[multitude_second.index])
                    case 2:
                        unification(multitudes[multitude_first.index], multitudes[multitude_second.index])
                    case 3:
                        difference(multitudes[multitude_first.index], multitudes[multitude_second.index])
                    case 4:
                        symmetric_difference(multitudes[multitude_first.index], multitudes[multitude_second.index])
                    case 5:
                        addition(multitudes[multitude_first.index], U)
            case 4:
                multitude = get_multitude_by_user_input()
                if len(multitudes[multitude.index]) == 0:
                    print(f'Ошибка: множество {multitude.name} пустое.')
                    continue
                while True:
                    try:
                        element = int(input('Введите элемент:'))
                        belong_to_multitude(element, multitudes[multitude.index])
                        break
                    except ValueError:
                        print('Ошибка: элемент должен быть целым числом')
            case 5:
                multitude_first = get_multitude_by_user_input('Выберите первый операнд (множество):')
                if len(multitudes[multitude_first.index]) == 0:
                                    print(f'Ошибка: множество {multitude_first.name} пустое.')
                                    continue
                multitude_second = get_multitude_by_user_input('Выберите второй операнд (множество):')
                if len(multitudes[multitude_second.index]) == 0:
                                    print(f'Ошибка: множество {multitude_second.name} пустое.')
                                    continue
                entry(multitudes[multitude_first.index], multitudes[multitude_second.index])
            case 6:
                print_all_multitudes(multitudes, U)
            case 7:
                print('Выход.')
                return
  

# === 0. Диалог, возвращающий выбранное пользователем имя множества и его позицию в виде структуры
def get_multitude_by_user_input(title='Выберите множество:'):
    multitude_choice = run_menu(f'{title}\n' \
                                '1. A\n' \
                                '2. B\n' \
                                '3. C\n' \
                                '4. D\n' \
                                '5. E\n',
                                5)
    match(multitude_choice):
        case 1:
            multitude = 'A'
        case 2:
            multitude = 'B'
        case 3:
            multitude = 'C'
        case 4:
            multitude = 'D'
        case 5:
            multitude = 'E'
    return Multitude(multitude, multitude_choice-1)


# ==== 0. Запускает диалог с пользователем с выбором пункта меню ====
def run_menu(text, max_menu_number):
    while True:
        print(text)
        try:
            choice = int(input(f'Выберите пункт (1-{max_menu_number}): '))
            if choice > 0 and choice <= max_menu_number:
                return choice
            else:
                print('Ошибка: выбран несуществующий пункт меню.')
        except ValueError:
            print('Ошибка: пункт меню должен быть целым числом.')


# === 0. Вывести все множества на печать ===
def print_all_multitudes(multitudes, U):
    print('\nСписок множеств и их значения:')
    print(f'1. Универсальное множество U: {U}')
    print(f'2. Множество A: {multitudes[0]}')
    print(f'3. Множество B: {multitudes[1]}')
    print(f'4. Множество C: {multitudes[2]}')
    print(f'5. Множество D: {multitudes[3]}')
    print(f'6. Множество E: {multitudes[4]}')


# ==== 1. Заполнение U ====
def input_U():
    try:
        U = []
        for num in input("Введите элементы универсального множества U (целочисленные через пробел, без повторов):").split():
            if int(num) not in U:
                U.append(int(num))
            else:
                raise CountException(num)
        print(f'Множество U: {U}')
        return U
    except ValueError:
        print("Ошибка: Ввод должен быть целочисленным.")
        exit()
    except CountException as exception:
        print(f"Ошибка: элемент {exception} используется в универсальном множестве два или более раз.")
        exit()


# === 2.1 Заполнение множества вручную ====
def input_multitudes_manually(multitude_name, U):
    if len(U) == 0:
            print('Ошибка: универсальное множество U пустое')
            return
    try:
        multitude = []
        for num in input(f"Введите элементы множества {multitude_name} (целочисленные через пробел): ").split():
            if int(num) not in multitude:
                if int(num) in U:
                    multitude.append(int(num))
                else:
                    raise NotInUException(num)
            else:
                raise CountException(num)
        print(f'Множество {multitude_name}: {multitude}')
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
    if len(U) == 0:
        print('Ошибка: универсальное множество U пустое')
        return
    multitude = []
    count = int(input(f"Введите количество элементов, которое будет сгенерировано в множество {multitude_name}: "))
    i = 0
    while i < count:
        num = U[random.randint(0, len(U)-1)]
        if num not in multitude:
            multitude.append(num)
            i+=1
    print(f'Множество {multitude_name}: {multitude}')
    return multitude


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
def belong_to_multitude(element, multitude):
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