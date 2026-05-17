#List exersice
#Ex 1
def list_sum(arr :list):
    total_sum = 0
    for item in arr:
        total_sum += item
    return total_sum 

#Ex 2
def maxi(arr):
    max_num = -9999999999999
    for num in arr:
        if num > max_num: max_num = num
    return max_num

#Ex 3
def occurrences(arr , n):
    number_apper_counter = 0
    for num in arr:
        if num == n:
            number_apper_counter +=1
    return number_apper_counter

#Ex 4
def reverseing(arr):
    new_arr = []
    for index in range(len(arr)-1,-1,-1):
        new_arr.append(arr[index])
    return new_arr

#Ex 5
def not_ducplicate(arr):
    new_arr = []
    for item in new_arr:
        if item not in new_arr:
            new_arr.append(item)
    return new_arr

#Ex 6
def second_max(arr):
    max_number = 0
    second_to_max = 0
    for num in arr:
        if num > max_number: 
            second_to_max = max_number
            max_number = num
        elif num > second_to_max and num < max_number:
            second_to_max = num
    return second_to_max

#Ex 7
def sort_two_list(arr1, arr2):
    arr1.extend(arr2)
    arr1.sort()
    return arr1
# print(sort_two_list([2,3,1],[5,4,6]))

#Ex 8
def rotate(arr , k):
    k = k % len(arr)
    for index in range(k):
        val = arr.pop()
        arr.insert(0,val)
    return arr
print(rotate([1, 2, 3, 4, 5],7))