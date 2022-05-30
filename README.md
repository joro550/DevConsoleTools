# Command line tools
I wanted to create a command line tool that could do some stuff that I was using different websites for daily


# How to use
Each release should have a `dev.exe` file, you can download this file into a folder of your choice then set a environment varibable to go to that folder and just type `dev` plus the command you want to run i.e. `dev gg`

---


Here are a few that are currently supported:

> Generate a random guid

```
generate guid [--hyphens true|false] [--uppercase true|false]
```

```
gg [--hyphens true|false] [--uppercase true|false]
```

> Generate a random email

```
generate email
```

> Generate a random number

```
generate number [--min 0] [--max 1]
```


> Generate a lorem ipsum words

```
generate lorem [--word-count 1]
```

> Base64 encode value

```
base64 encode <value>
```

> Base64 decode value

```
base64 decode <value>
```


> Upper case string

```
string to-upper <value>
```

> Lower case string

```
string to-lower <value>
```




