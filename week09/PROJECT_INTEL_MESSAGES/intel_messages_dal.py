import mysql.connector as seqel
import setup_messages



class IntelMessagesDAL:
    VALID_CLASSIFICATIONS = ('unclassified', 'confidential', 'secret',
    'top_secret')

    def __init__(self,host: str, user: str, password: str, database: str):
        self.host = host
        self.user = user
        self.password = password
        self.database = database

    def get_conn(self):
        cnx = seqel.connect(
            host = self.host,
            port = 3308,
            database = self.database,
            user = self.user,
            password = self.password
        )
        
        return cnx
    
    def setup(self):
        pass

    def get_schema(self)-> list[dict]:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql = "DESCRIBE intel_messages"

        cursor.execute(sql)

        rows = cursor.fetchall()

        cursor.close()
        conn.close()

        return rows

    def get_all(self):
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql = "SELECT * FROM intel_messages"
        cursor.execute(sql)

        rows = cursor.execute(sql)
        cursor.close()
        conn.close()

        return rows
    
    def get_by_id(self,message_id:int)-> dict | None:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql = "SELECT * FROM WHERE id = %s"

        cursor.execute(sql,(message_id,))

        row = cursor.fetchone()
        cursor.close()
        conn.close()
        return row
    
    def create(self, unit: str, classification: str, content: str, source: str
    | None) -> int:
        conn = self.get_conn()
        cursor = conn.cursor() 

        sql_promt = """
        INSERT INTO intel_messages (unit,classification,content,source) VALUES (%s,%s,%s,%s)
        """
        values = (unit,classification,content,source)
        cursor.execute(sql_promt,values)

        conn.commit()
        new_id = cursor.lastrowid

        cursor.close()
        conn.close()

        return new_id

    def update(self, message_id: int, data: dict) -> bool:
        conn = self.get_conn()
        cursor = conn.cursor()

        set_parts = [f"`{key}`" for key in data.keys()]
        set_clause = ", ".join(set_parts)
        values =  list(data.values) + [message_id]

        sql_promt = f"""
        UPDATE intel_messages SET {set_clause} WHERE id = %s
        """

        cursor.execute(sql_promt,values)
        conn.commit()

        is_changed = cursor.rowcount > 0
        cursor.close()
        conn.close()

        return is_changed

    def delete(self, message_id: int) -> bool:
        conn = self.get_conn()
        cursor = conn.cursor()

        sql_promt = """
        DELETE FROM intel_messages WHERE id = %s
        """

        cursor.execute(sql_promt,message_id)
        conn.commit()

        is_deleted = cursor.rowcount > 0 

        cursor.close()
        conn.close()

        return is_deleted

    def get_by_unit(self, unit: str) -> list[dict]:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql_promt = """
        SELECT * FROM intel_messgaes WHERE unit = %s ORDER BY created_at DESC
        """
        
        cursor.execute(sql_promt,unit)

        rows = cursor.fetchall()
        cursor.close()
        conn.close()

        return rows

    def get_by_classification(self, classification: str) -> list[dict]:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql_promt = """
        SELECT * FROM intel_messages WHERE classification = %s
            """
        cursor.execute(sql_promt)
        rows = cursor.fetchall()

        cursor.close()
        conn.close()

        return rows

    def get_by_unit_and_classification(self, unit: str, classification: str) -> list[dict]:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql_promt = """
        SELECT * FROM intel_messages WHERE unit = %s AND WHERE classification = %s
         """
        cursor.execute(sql_promt)

        rows = cursor.fetchall()

        cursor.close()
        conn.close()

        return rows
    
    def get_distinct_units(self) -> list[str]:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql_promt = """
        SELECT DISTINCT unit FROM intel_messages
        """

        cursor.execute(sql_promt)

        rows_dict = cursor.fetchall()
        rows_list = [val for val in rows_dict.values()]
        cursor.close()
        conn.close()

        return rows_list
    
    def search_content(self, term: str) -> list[dict]:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql_promt = """
        SELECT * FROM intel_messages WHERE content LIKE %s
        """
        cursor.execute(sql_promt,(term,))

        rows = cursor.fetchall()

        cursor.close()
        conn.close()

        return rows
    
    def get_missing_source(self) -> list[dict]:
        conn = self.get_conn()
        cursor = conn.cursor(dictionary=True)

        sql_promt = """
        SELECT * FROM intel_messgaes WHERE source IS NULL
        """

        cursor.execute(sql_promt)

        rows = cursor.fetchall()

        cursor.close()
        conn.close()

        return rows
    

