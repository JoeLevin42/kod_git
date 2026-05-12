#Ex 1
def is_real_age(age):
    if age < 0 or age >120:
        print("Invalid")
    elif age <=12:
        print("Child")
    elif age > 12 and age <= 17:
        print("Teen ")
    elif age > 17 :
        print("Adult")
    
#Ex 2
def is_vowel(text):
    if "auieo" in text:
        print("Vowel")
    elif text.isalpha() and text.isascii():
        print("Constant")
    else:
        print("Invalid")

#Ex 3
def enter_is_approval(age,vip:bool):
    if age < 16:
        print("Enter reject")
    elif age >= 18 and vip:
        print("WELCOME")
    elif age in range(19,22):
        print("WELCOME")
    else:
        print("Soory you cant get in")

#Ex 4
def password_check(password):
    PASSWORD = "12345678"
    if password == PASSWORD:
        print("Access granted")
    elif len(password) <8:
        print("Too short")
    else:
        print("WRONG PASSWORD")

#Ex 5
def is_inside_rectangle(x,y):
    if x in range(20,51) and y in range(20,81):
        if x == 20 or x == 50 or y == 20 or y == 80:
            print("On the adge")
        else:
            print("inside")

    else:
        print("SORRY you outside")

#Ex 6
def greeting():
    user_input = input("Enter your name") or "Anonymous"
    print(f"Hello {user_input}")

#Ex 7
def is_positive(num1,num2,num3):
    positive_nums = bool(num1>0) + bool(num2>0) + bool(num3>0)
    print(positive_nums)
is_positive(1,1,-1)

#Ex 8
def check_score(score):
    print("A") if score in range(90,101) else print("B") if score in range(80,90) else print("C") if score in range(70,80) else print("F") if score < 70 and score >0 else None
