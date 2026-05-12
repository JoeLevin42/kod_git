#Ex 1
def is_even(num):
    return bool( not num%2)

#Ex 2
def swap(num1,num2):
    num1 = num1 + num2
    num2 = num1 - num2
    num1 = num1 - num2
    print(num1,num2)
swap(5,6)

#Ex 3
def sum_digit(num):
    total = 0
    total += num % 10
    num = num // 10
    total += num%10
    num = num // 10
    total += num%10
    return total
print(sum_digit(123))

#Ex 4
def bmi(weight, height):
    bmi = weight / (height**2)
    return round(bmi,2) 
print(bmi(60,1.70))

#Ex 5
def two_parts(num:float):
    number = int(num)
    remainder = num%1
    print(f"the full number is {number} , the remainder is {remainder}")
two_parts(15.5)

num =3 
print("a") if num>3 else print("b")