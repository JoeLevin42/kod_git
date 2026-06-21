from fastapi import FastAPI , HTTPException
import uvicorn
from intel_messages_dal import IntelMessagesDAL


intel_manager = IntelMessagesDAL("localhost",user="root",password="root",database = "soldiers_db")

app = FastAPI()

@app.get("/schema")
def get_schema():
    return intel_manager.get_schema()

@app.get("/messages")
def get_messages(unit: str= None ,classification: str = None):

    if unit and classification:
        return intel_manager.get_by_unit_and_classification(unit=unit,classification=classification)
    
    if unit:
        return intel_manager.get_by_unit(unit=unit)
    
    if classification:
        return intel_manager.get_by_classification(classification=classification)
    
@app.get("/messages/units")
def get_units():
    return intel_manager.get_distinct_units()

@app.get("/messages/search")
def get_messages_search(q: str):
    if not q:
        raise HTTPException(status_code=400 , detail="The q term is invalid")
    return intel_manager.search_content(q)


@app.get("/messages/missing-source")
def get_missing_source():
    return intel_manager.get_missing_source()

@app.post("/messages",status_code=201)
def create(payload:dict):
    return intel_manager.create(payload:dict)

@app.get("/messages/{message_id}")
def get_by_id(message_id:int)
    id_exist = intel_manager.get_by_id(message_id=message_id)
    if not id_exist:
        raise HTTPException(status_code=404, detail="The id not exist")

    intel_manager.delete(message_id=message_id)

