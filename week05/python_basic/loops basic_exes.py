def ex1():
    is_run = True
    cnt = 0
    while is_run:
        cnt +=1
        if cnt == 7:
            break
        if cnt%2 == 0:
            print("even")
        else:
            continue

#Ex 2
def ex2():
    PASSWORD = "1234"
    while True:
        user_input = input("Enter")
        if user_input == PASSWORD:
            print("WELCOME!")
            break
        else:
            print("try agin")

#Ex 3
def ex3():
    break_word = "done"
    listi = []
    while True:
        user_input = input("Enter")
        if user_input == break_word:
            print(listi)
            break
        listi.append(user_input)
#Ex 4
def ex4():
    vowel_cnt = 0
    user_input = input("Enter")
    for char in user_input:
        if char.lower() in "auieo":
            vowel_cnt +=1
    print(f"the vowels in the string is: {vowel_cnt}")

#Ex 5
def ex5():
    
    for i in range(1,6):
        for j in range(1,6):
           print(f"{i}X{j} = {i*j}")
#Ex 6
def ex6():
    original_str = input("Enter")
    reversed_str = ""
    for i in range(len(original_str)-1,-1,-1):
        reversed_str += original_str[i]
    print(reversed_str)

#Ex 7
def ex7():
    even_cnt = 0
    num = 1232
    while num>0:
        if num % 2 == 0:
            even_cnt +=1
        num //= 10
    print(even_cnt)

#Ex 8
def ex8():
    string= "abc"
    double_str = ""
    for i in string:
        double_str += i + i
    print(double_str)

#Ex 9
def ex9():
    maxi = 0
    while True:
        user_input = input("enter a number")
        if user_input == "0":
            print(maxi)
            break
        if int(user_input) > maxi:
            maxi = int(user_input)

#Ex 10
def ex10():
    no_secial_char = True
    string_inout = input("Enter stirng")
    for  char in string_inout:
        if not char.isalpha() and not char.isnumeric():
            no_secial_char = False
    print(no_secial_char)

#Ex 11
def ex11():
    digits = 123
    reversed_digits = 0
    counter = 100
    while digits >0:
        reversed_digits += (digits %10) * counter
        counter //= 10
        digits //= 10
    print(reversed_digits)

#Ex 12
def ex12():
    for row in range(1,4):
        for col in range(1,4):
            if col == 2:
                break
            else:
                print(row,col)










            
        

