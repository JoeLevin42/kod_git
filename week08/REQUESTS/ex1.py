import requests

response = requests.get("https://jsonplaceholder.typicode.com/users/1")

js_dict = response.json()
print(js_dict["name"])
print(js_dict["email"])
print(js_dict["address"]["city"])

