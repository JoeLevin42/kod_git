#Exeption exersices 
#Ex 1
def safe_int(s):
    try:
        num = int(s)
    except ValueError:
        return None
    except TypeError:
        return None
    except:
        return None
    
#Ex 2
def safe_divide(a , b):
    try:
        return a/b
    except ZeroDivisionError:
        return "undefined"
    
#Ex 3
def get_value(d , key):
    try:
        return d[key]
    except KeyError:
        return "Missing"

#Ex 4
def parse_ints(values):
    new_list = []
    for n in values:
        try:
            new_list.append(int(n))
        except:
            continue
        
    print(new_list)

#Ex 5
def set_age(age):
    if age <= 0 or age > 150:
        raise ValueError("Invalid age")
    return age

#Ex 6
def retry(func , n):
    for _ in range(n):
        try:
            func()
        except Exception as e:
            last_error = e
    raise last_error

#Ex 7
funcs = [lambda : 1/0 , lambda : int("a") , lambda : int("3.14")]
def count_errors(funcs):
    err_cnt = 0
    for fn in funcs:
        try:
            fn()
        except:
            err_cnt += 1
    return err_cnt      
        
#Ex 8
def load_config(path):
    try:
        with open(path,"r",encoding="UTF-8") as f:
            line = f.readline()
            line = int(line)
    except Exception as e:
        raise RuntimeError("failed to load config") from e

load_config("enjfjwerjgfjweroi")
        


