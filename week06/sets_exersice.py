#Sets exercises
#Ex 1
def not_duplicate(listi : list ):
    return list(set(listi))

#Ex 2
def count_uniq(listi : list):
    uniq_counter = 0
    for num in set(listi):
        uniq_counter +=1
    return uniq_counter

#Ex 3
def common_nums(list1: list , list2 : list):
    common_list = set(list1).intersection(set(list2))
    return list(common_list)


#Ex 4
def different_nums(list1 : list , list2 : list):
    different_nums = set(list1).symmetric_difference(list2)
    return list(different_nums)

#Ex 5
def is_subset(set1 : set , set2 :set):
    return set1.issubset(set2)

#Ex 6
def is_distinct(string :str ):
    return len(string) == len(set(list(string)))

#Ex 7 
def is_not_uniq(listi : list):
    seen = set()
    for element in listi:
        if element not in seen:
            seen.add(element)
            
        else:
            return element
    return None

#Ex 8
def distinct_word(string : str):
    return len(set(word.lower() for word in string.split()))

#EX 9
def is_target(arr : list , target : int):
    check_set = set()
    for num in arr:
        complement = target - num
        if complement in check_set:
            return True
        check_set.add(num)

    return False

#Ex 10
def symmetric_different_list(arr1 :list , arr2:list):
    
    new_list = []
    set1 = set(arr1)
    set2= set(arr2)
    for num in arr1:
        if num not in set2:
            new_list.append(num)
    for num in arr2:
        if num not in set1:
            new_list.append(num)
    return new_list
print(symmetric_different_list([1, 2, 3, 4], [3, 4, 5, 6]))
c
