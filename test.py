class Livre
	def __init__(self,num,auth,title,available=True)
			self.num=num
			self.auth=auth
			self.title=title
			self.available=available
	def print (self)
		print(self.auth,self.title,self.title)
	
	
	
class User
	def __init__(self,num,nom,prenom)
			self.num=num
			self.nom=nom
			self.prenom=prenom

class Liste
	def __init__(self,livres)
		self.livres=livres
	def printlivre(self)
		for i in self.livres
			i.print()
	def printlivred(self)
		for i in self.livres
			if i.available==True
				i.print()
	def printlivredn(self)
		for i in self.livres
			if i.available==False
				i.print()
	def lendtitle(self,title)
		for i in self.liste
			if i.title==title
				i.available=False
				return True
			return False
				i.print()
	def lendtitle(self,isbn)
		for i in self.liste
			if i.num==isbn
				i.available=False
				return True
			return False
			
	def returnbook(self,isbn)
		for i in self.liste
			if i.num==isbn and i.available==False
				i.available=True
				return True
			return False