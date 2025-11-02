import tkinter as tk
from tkinter import ttk, messagebox
from collections import namedtuple

IncomeData = namedtuple("IncomeData", 
                        ["month1", "month2", "month3", 
                         "month4", "month5", "month6"])

def get_deduction(entrepreneur: str, 
                  income: IncomeData, 
                  pension_deduction: float) -> str:
    
    total_income_H = sum(income)
    average_income_SN = total_income_H / 6.0
    deduction_rate = pension_deduction / 100.0
    
    net_profit = total_income_H - (total_income_H * deduction_rate) - average_income_SN
    
    return (f"Підприємець {entrepreneur} – ваш чистий дохід складає "
            f"{net_profit:.2f}")


def handle_calculate():
    
    try:
        name = entry_name.get()
        if not name:
            messagebox.showwarning("Помилка вводу", "Прізвище не може бути порожнім.")
            return

        income_values = []
        for entry in income_entries:
            income_values.append(float(entry.get()))
            
        income_data = IncomeData(*income_values)

        deduction = float(spin_deduction.get())
        
        if not (5 <= deduction <= 15):
            messagebox.showwarning("Помилка вводу", 
                                   "Відсоток відрахувань має бути в межах від 5 до 15.")
            return
            
        result_string = get_deduction(name, income_data, deduction)
        
        result_var.set(result_string)

    except ValueError:
        messagebox.showerror("Помилка даних", 
                             "Будь ласка, введіть коректні числові дані для доходів.")
    except Exception as e:
        messagebox.showerror("Невідома помилка", f"Сталася помилка: {e}")


root = tk.Tk()
root.title("Розрахунок чистого доходу")
root.geometry("400x450")

main_frame = ttk.Frame(root, padding="15")
main_frame.pack(fill=tk.BOTH, expand=True)

label_name = ttk.Label(main_frame, text="Прізвище підприємця:")
label_name.pack(anchor="w")
entry_name = ttk.Entry(main_frame, width=40)
entry_name.pack(fill="x", pady=5)
entry_name.insert(0, "Петренко") 

label_incomes = ttk.Label(main_frame, text="Доходи за 6 місяців:")
label_incomes.pack(anchor="w", pady=(10, 0))

income_frame = ttk.Frame(main_frame)
income_frame.pack(fill="x", pady=5)

income_entries = []
default_incomes = [10000, 11000, 9500, 12000, 10500, 11500]

for i in range(6):
    row, col = divmod(i, 2) 
    
    frame_month = ttk.Frame(income_frame)
    frame_month.grid(row=row, column=col, padx=5, pady=2, sticky="w")
    
    ttk.Label(frame_month, text=f"Місяць {i+1}:").pack(side=tk.LEFT)
    entry = ttk.Entry(frame_month, width=12)
    entry.pack(side=tk.LEFT)
    entry.insert(0, str(default_incomes[i]))
    income_entries.append(entry)

label_deduction = ttk.Label(main_frame, text="Відсоток відрахувань (5-15%):")
label_deduction.pack(anchor="w", pady=(10, 0))

spin_deduction = ttk.Spinbox(main_frame, from_=5.0, to=15.0, 
                             increment=0.5, width=10)
spin_deduction.pack(anchor="w", pady=5)
spin_deduction.set(10.0) 
calc_button = ttk.Button(main_frame, text="Розрахувати", 
                         command=handle_calculate)
calc_button.pack(pady=15)

result_var = tk.StringVar()
result_label = ttk.Label(main_frame, 
                         textvariable=result_var, 
                         font=("Arial", 11, "bold"),
                         wraplength=350, 
                         foreground="blue")
result_label.pack(pady=10)


root.mainloop()
