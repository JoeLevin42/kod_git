import requests
# PUT — replace the entire resource
updated = {"id":1,"title":"New Title","body":"New content","userId":1}
r = requests.put("https://jsonplaceholder.typicode.com/posts/1", json=updated)
print(r.status_code)
# 200
# DELETE — remove the resource
r = requests.delete(
"https://jsonplaceholder.typicode.com/posts/ggg"
)
print(r.status_code)
# 200 (some APIs return 204 No Content) 
