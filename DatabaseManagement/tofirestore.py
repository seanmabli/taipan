from firebase import firebase
fb_app = firebase.FirebaseApplication('https://taipan-354222-default-rtdb.firebaseio.com/', None)
new_user = 'Ozgur Vatansever'

result = fb_app.post('/users', new_user, {'print': 'pretty'}, {'X_FANCY_HEADER': 'VERY FANCY'})
print (result)

result = fb_app.post('/users', new_user, {'print': 'silent'}, {'X_FANCY_HEADER': 'VERY FANCY'})
print (result == None)