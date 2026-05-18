#Tuple Excercise
#Ex 1
def sum_of_tuple(numbers):
    sum_total = 0 
    for num in numbers:
        sum_total += num

#Ex 2
def max_num(numbers):
    maxi = -9999
    for num in numbers:
        if num > maxi:
            maxi = num
    return maxi

#Ex 3
def occurences(tuple_of_bumbers , value):
    occurences_cnt = 0
    for val in tuple_of_bumbers:
        if val == value:
            occurences_cnt +=1 
    return occurences_cnt

#Ex 4
def reverse_tuple(tuple_kind):
    result = tuple()
    for value in tuple_kind:
        result = (value , *result)
    return result

#Ex 5
def swap_pairs(even_tuple):
    new_tup = ()
    for index in range(0,len(even_tuple)-1,2):
        new_tup = (*new_tup ,even_tuple[index+1],even_tuple[index])
    return new_tup

#Ex 6
def min_max(numbers_tuple):
    mini = numbers_tuple[0]
    for num in numbers_tuple:
        if num < mini: mini = num
    maxi = -999999
    for num in numbers_tuple:
        if num > maxi : maxi = num
    min_max_tup = (mini,maxi)
    return min_max_tup

#Ex 7
def get_distance(point_a : tuple, point_b :tuple):
    distance= (((point_a[0] - point_b[0])**2) + ((point_b[1] - point_a[1])**2))**0.5
    return distance

#Ex 8
def merge_sort(tuple1,tuple2):
    merged_tuple = (*tuple1,*tuple2)
    merged_tuple  = sorted(merged_tuple)
    return tuple(merged_tuple)

#Ex 9
def count_char_to_pairs(chars_tuple):
    new_tup = ()
    
    for char in chars_tuple:
        char_cnt = chars_tuple.count(char)
        if (char,char_cnt) not in new_tup:
            new_tup = (*new_tup ,(char,char_cnt))
    return new_tup

#Ex 10
def rotate_tuple(tupli , k):
    k = k%len(tupli)
    return *tupli[-k:],*tupli[:-k]
  


 