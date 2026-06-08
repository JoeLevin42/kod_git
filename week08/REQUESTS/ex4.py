import requests


def create_action():
    response_users = requests.get("https://jsonplaceholder.typicode.com/users")
    response_posts = requests.get("https://jsonplaceholder.typicode.com/posts")

    dict_list = []

    for user in response_users.json():
        name = user.get("name")
        if name not in dict_list:
            dict_list.append({"id":user.get("id"),"name":name})
    
    for us in dict_list:
        us_id = us.get("id")
        for post in response_posts.json():
            if post.get("id") == us_id:
                result = requests.post("https://jsonplaceholder.typicode.com/posts",json= {"name":f"{us.get("name")}"})   
                print(result.status_code)
create_action()