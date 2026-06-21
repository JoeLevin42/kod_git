import mysql.connector

def get_connection():
    cnx = mysql.connector.connect(
        host= "localhost",
        user = "root",
        password = "root"
    )

    return cnx


def create_db():
    conn = get_connection()
    my_crusor = conn.crusor()

    query = """
    CREATE DATABASE

        """