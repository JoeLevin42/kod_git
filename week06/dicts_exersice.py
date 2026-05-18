#dicts exersices
#Ex 1
def sum_all(dicti : dict):
    total_sum = 0
    for val in dicti.values():
        total_sum += val
    return total_sum

#Ex 2
def get_max_val(dicti : dict):
    maxi = (None,-9999999999)
    for key , val in dicti.items():
        if val < maxi[1]:
            maxi = (key,val)
    return maxi[0]

#Ex 3
def occurences_count_dict(word : str):
    occurences_dict = {}
    for char in word:
        if char not in occurences_dict:
            occurences_count_dict[char] = 1
        else:
            occurences_count_dict[char] +=1
    return occurences_dict

#Ex 4
def swap_key_val(dicti : dict):
    swapped_dict = {}
    for key ,val in dicti.items():
        swap_key_val[val] = key
    return swapped_dict

#Ex 5
def merge_to_dict(current_dict , new_dict):
    current_dict.update(new_dict)
    return current_dict

#Ex 6
def threshold_filter(dicti : dict , threshold):
    filterd_dict = {}
    for key , val in dicti.items():
        if val > threshold:
            filterd_dict[key] = val
    return filterd_dict

#Ex 7
def first_letter_key(word_list : list):
    dicti = {}
    for word in word_list:
        if word[0] not in dicti:
            dicti[word[0]] = [word]
        else:
            dicti[word[0]].append(word)

    return dicti

#Ex 8
def separate_str(word : list):
    list_str = word.split(" ")
    appears_dict = {}
    for word in list_str:
        if word not in appears_dict:
            appears_dict[word] = 1
        else:
            appears_dict[word] +=1
    return appears_dict

#Ex 9
def get_common_keys(dict1 : dict , dict2 :dict):
    dict1_keys = dict1.keys()
    dict2_keys = dict2.keys()
    common_keys = []
    for key in dict1_keys:
        if key in dict2_keys:
            common_keys.append(key)
    return common_keys

#Ex 10
def most_frequent_key(dicti : dict):
    count_dict = {}
    for num in dicti.values():
        if num not in count_dict:
            count_dict[num] = 1
        else:
            count_dict[num] +=1
    # key is the num and v is the appears 
    max_counter = 0
    best_nums = None

    for num , count in count_dict.items():
        if count > max_counter:
            max_counter = count
            best_nums = [num]

        elif count == max_counter:
            best_nums.append(count)
    

    if len(best_nums) == 1:
        return best_nums[0]    
    return best_nums

print(most_frequent_key({"a": 1, "b": 2, "c": 1, "d": 3}))
    
    






       

    


