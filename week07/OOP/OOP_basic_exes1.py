
#Ex1
class Dog:
    """
    Simple example for dog instance an methood
    """
    def __init__(self,name):
        self.name = name
    
    def bark(self):
        print(f"{self.name} , say woof")

# d1 = Dog("Rex")
# d1.bark()

#Ex 2
class Rectangle:
    """
    This class have attributes of rectangle 
    and return the area of him
    """
    def __init__(self,width,height):
        self.width = width
        self.height = height
    
    def area(self):
        return self.width * self.height

# ric = Rectangle(3,4)
# print(ric.area())

#Ex 3
class Counter:
    """
    This class is an example for simple increment
    inside the constructor
    """
    def __init__(self):
        self.counter = 0

    def increment(self):
        self.counter +=1
    
    def value(self):
        print(self.counter)

# c = Counter()
# c.increment()
# c.increment()
# c.value()

#EX 4
class Point:
    """
    This class is an example for return the 2 points
    with the magic methood __str__
    """
    def __init__(self,a,b):
        self.a = a
        self.b = b
    def __str__(self):
        return f"{self.a},{self.b}"
    
# print(Point(1,2))

#Ex 5
class BankAccount:
    """
    This class is simple example for attributes and
    methods in the simple bank example
    """
    def __init__(self):
        self.balance = 0

    def deposite(self,amount):
        self.balance += amount

    def withdraw(self,amount):
        if amount > self.balance:
            self.balance -+ amount

    def __str__(self):
        return f"Balance : {self.balance}"

# b = BankAccount()
# b.deposite(50)
# b.withdraw(30)

#Ex 6
class Temperature:
    """
    This class is return with the magic method
    the temperature with possible to convert it
    to another format
    """
    def __init__(self,temperature):
        self.temperature = temperature

    def to_fahrenheit(self):
        fahrenheit = (self.temperature * 9/5) + 32
        self.temperature = fahrenheit
    
    def __str__(self):
        return f"Temperature : {self.temperature}"

# t= Temperature(100)
# print(t)
# t.to_fahrenheit()
# print(t)

#Ex 7
class Student:
    """
    This class just an example that it possible
    to create one Class withe the same attribute
    to many object with different names
    """
    def __init__(self,name):
        self.school = "kodcode"
        self.name = name

# s1= Student("Jhony")
# s2= Student("Dudi")
# print(s1.name)
# print(s2.name)

#Ex 8
class Player:
    """
    This class is an example to class variable
    that increment himself in every instanstiation
    """
    counter = 0
    def __init__(self,name,age):
        self.name = name
        self.age = age
    
        Player.counter +=1

# p1 = Player("Dani",20)
# p2 = Player("David",22)
# print(Player.counter)

#Ex 9
class Money:
    """
    This class conatains money amount and method that 
    check if the first object bigger the the other
    """
    def __init__(self,amount):
        self.amount = amount

    def is_more_than(self,other):
        if self.amount > other.amount:
            print("Yes it bigger")
        else:
            print("No is smaller than the other")

# m1 = Money(50)
# m2 = Money(30)
# m1.is_more_than(m2)

#Ex 10
class PlayList:
    """
    This class init with empty list and you can 
    add/remove song in every instance
    """
    def __init__(self):
        self.songs = []

    def add(self,song):
        self.songs.append(song)
    
    def remove_song(self,song):
        self.songs.remove(song)

    def __str__(self):
        return f"songs : {" ".join(self.songs)}"
        
my_play = PlayList()
my_play.add("kalalka")
my_play.add("blabla")
print(my_play)
my_play.remove_song("kalalka")
print(my_play)
