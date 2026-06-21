import mysql.connector

def create_database():
    cnx = mysql.connector.connect(
        host = "localhost",
        user = "root",
        password = "root",
    )

    my_cursor = cnx.cursor()

    my_cursor.execute("CREATE DATABASE IF NOT EXISTS db;")    
    print("Data base successfully created!")

    my_cursor.close()
    cnx.close()


def create_table_schema():
    cnx = mysql.connector.connect(
        host = "localhost",
        database = "db",
        user = "root",
        password = "root",
    )

    my_cursor = cnx.cursor()

    query = """
    CREATE TABLE IF NOT EXISTS soldiers (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    ranki VARCHAR(50),
    unit VARCHAR(100),
    active BOOLEAN DEFAULT TRUE
    );
    """

    my_cursor.execute(query)
    print("ITS WORKED")

    my_cursor.close()
    cnx.close()

def get_connection():
    cnx = mysql.connector.connect(
        host= "localhost",
        database = "db",
        user = "root",
        password = "root"
    )

    return cnx



def insert_data_to_table(name:str,ranki:str,unit:str):
    cnx = mysql.connector.connect(
        host = "localhost",
        database = "db",
        user = "root",
        password ="root"
    )

    sql = "INSERT INTO soldiers (name,ranki,unit) VALUES (%s,%s,%s)"
    values = (name,ranki,unit)
    my_cursor = cnx.cursor()

    my_cursor.execute(sql,values)
    cnx.commit()

    new_id = my_cursor.lastrowid

    my_cursor.close()
    cnx.close()
    return new_id


def update_something(soldier_id:int,data:dict):
    conn = get_connection()
    my_cursor = conn.cursor()

    set_parts = [f"{key}=%s" for key in data.keys()]
    set_clause = ",".join(set_parts)

    sql = f"UPDATE soldiers SET {set_clause} WHERE id = %s"
    values = list(data.values()) + [soldier_id]

    my_cursor.execute(sql,values)
    conn.commit()
    
    changed = my_cursor.rowcount > 0

    my_cursor.close()
    conn.close()
    return changed

def delete(soldier_id: int)->bool:
    conn = get_connection()
    my_cursor = conn.cursor()

    my_cursor.execute("DELETE FROM soldiers WHERE id = %s",(soldier_id,))
    conn.commit()

    deleted = my_cursor.rowcount > 0

    my_cursor.close()
    conn.close()

    return deleted

def get_all()->list:
    conn = get_connection()
    my_cursor = conn.cursor(dictionary=True)

    my_cursor.execute("SELECT * FROM soldiers")
    rows = my_cursor.fetchall()

    my_cursor.close()
    conn.close()
    return rows

def get_by_id(soldier_id:int):

    conn = get_connection()
    my_cursor = conn.cursor(dictionary =True)

    my_cursor.execute("SELECT * FROM soldiers WHERE id = %s",(soldier_id,))
    row = my_cursor.fetchone()

    my_cursor.close()
    conn.close()

    return row




