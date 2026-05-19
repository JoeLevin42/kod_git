#scoup _ moudule exercises
#Ex 1
count = 0
def bump():
    global count
    count +=1
def get_val():
    print(count)
bump()
bump()
bump()
get_val()
#Ex 2
def make_counter():
    counter = 0
    def step():
        nonlocal counter
        counter +=1
        return counter
    return step

c = make_counter()
c()
c()
c()
#Ex 3
x = "global"
def outer():
    x = "enclosing"
    def inner():
        x = "local"
        print(x)
    inner()
    print(x)
outer()
print(x)
#Got it!

#Ex 4
listi = [1, 2, 3]
print(list(range(5)))

#Ex 7
from datetime import datetime as dt
print(dt.now())

#Ex 8
import math 
dired = sorted(dir(math))
filterd_dired = [word for word in dired if not word.startswith("_")]
print(filterd_dired)

#Ex 9
def add_item(item, bag=None):
    bag = [] if bag == None else bag
    bag.append(item)
    return bag

#Ex 10
import geometry.circle  as circle , geometry.rectangle as rectangle
print(circle.area(4))
print(rectangle.area(4,6))

