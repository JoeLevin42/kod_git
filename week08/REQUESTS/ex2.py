import requests

def safe_search(url):

    response = requests.get(url)

    match response.status_code:
        case 200:
    
            print("Ok the response worked well")
            return response.json()
        case 404: 
            print("O O The file not found")

        case _:
            raise Exception("somehting unexpected happend")