#Ex 1
def is_even(n):
    if n%2 == 0:
        return True
    return False

#Ex 2
def factorial(n):
    sum_total = 1
    for i in range(1,n):
        sum_total += sum_total *i
    return sum_total

#Ex 3
def digital_root(n):
    return n**2

#Ex 4
def is_palindrom(n):
    for char in range(len(str(n))//2):
        if str(n)[char] != str(n)[-char-1]:
            return False
    return True

#Ex 5
def func5(n):
    sum_total = n
    def sum_digits(sum_total):
        sum_here = 0 
        for num in str(sum_total):
            sum_here += int(num)
        return sum_here
    
    while len(str(sum_total))>1 :
       sum_total = sum_digits(sum_total)
    print(sum_total)

#Ex 6
def count_digit_nostr(n):
    cnt = 0
    while n>0:
        n //=10
        cnt+=1
    return cnt

#Ex 7
def smart_reverse(n):
    is_negative = False
    new_num = ""
    if n<0:
        n = abs(n)
        is_negative = True
    for i in range(len(str(n))-1,-1,-1):
        if str(n)[i] != "0":
            new_num += str(n)[i]
    if is_negative:
        return -int(new_num)
    return int(new_num)

#Ex 
def ends_with_zero(arr):
    len1 = len(arr)
    index = 0
    while index < len1:
        print(arr[index])
        if arr[index] == 0:
            arr.remove(0)
            arr.append(0)
        index +=1
    
    return arr
print(ends_with_zero([0,0,1,0,2,0,3,0,0,4]))
#Ex 9
def ex9(arr):
    def avarage(arr):
        avg = 0
        cnt = 0
        for n in arr:
            cnt +=1 
            avg= sum(arr) / cnt
        return avg
    print(sum(arr))  
    print(avarage(arr))
    print(max(arr))
    print(min(arr))
            
#Ex 9
def reverse_list(arr):
    new_arr = []
    for i in range(len(arr+1)-1,-1,-1):
        new_arr.append(i)
    return new_arr

#Ex 10
def not_double_list(arr):
    new_arr = list(set(arr))
    return new_arr

    
def a(arr):
    for val in arr:
        arr.remove(0)
        arr.append(0)
    return arr



    