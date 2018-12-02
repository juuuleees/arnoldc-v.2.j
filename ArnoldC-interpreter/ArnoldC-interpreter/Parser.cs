﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ArnoldCinterpreter {

    public class Parser {

    	Dictionary<int, Tuple<string, string>> symbol_table = new Dictionary<int, Tuple<string, string>>();
    	List<List<string>> program_expressions = new List<List<string>>();
    	
    	/*
			solid_index is for the main thing being parsed, flexi_index is for adjusting the symbol table.
    	*/

    	// int solid_index = 1;		
    	// int flexi_index = 1;
		bool valid_main_method;

		// finished
		public void main_method(Dictionary<int, Tuple<string, string>> lexeme_collection) {

			List<string> main_method_expr = new List<string>();
			int lexeme_count = lexeme_collection.Count();

			Console.WriteLine(lexeme_count);

			foreach (KeyValuePair<int, Tuple<string, string>> lexeme in lexeme_collection) {

				if (lexeme.Key == 0) {
					main_method_expr.Add(lexeme.Value.Item2);
				} else if (lexeme.Key == (lexeme_count - 1)) {
					main_method_expr.Add(lexeme.Value.Item2);
				}
			}

			if (main_method_expr.Contains("IT'S SHOWTIME") && main_method_expr.Contains("YOU HAVE BEEN TERMINATED")) {
				valid_main_method = true;
				Console.WriteLine("Main method valid.");
			} else if (!main_method_expr.Contains("IT'S SHOWTIME")) {
				Console.WriteLine("Error: Invalid main method. Missing keyword IT'S SHOWTIME.");
			} else if (!main_method_expr.Contains("YOU HAVE BEEN TERMINATED")) {
				Console.WriteLine("Error: Invalid main method. Missing keyword YOU HAVE BEEN TERMINATED.");
			}

		}    	

		// prioritize this!
		public void assign_variable(Dictionary<int, Tuple<string, string>> lexeme_collection) {

			List<string> hey_christmas_tree = new List<string>();
			List<string> you_set_us_up = new List<string>();
			string temp_str;
			int expression_size = 2;

			foreach(KeyValuePair<int, Tuple<string, string>> lexeme in lexeme_collection) {

				if (lexeme.Value.Item2 == "HEY CHRISTMAS TREE") {
					temp_str = lexeme.Value.Item2;
					hey_christmas_tree.Add(temp_str);

					if (lexeme_collection[lexeme.Key + 1].Item1 == "Variable identifier") {
						temp_str = lexeme_collection[lexeme.Key + 1].Item2;
						hey_christmas_tree.Add(temp_str);
					}

					if (lexeme_collection[lexeme.Key + 2].Item2 == "YOU SET US UP") {
						// Console.WriteLine("correct syntax!");
						you_set_us_up.Add(lexeme_collection[lexeme.Key + 2].Item2);

						if (lexeme_collection[lexeme.Key + 3].Item1 == "Integer literal") {
							temp_str = lexeme_collection[lexeme.Key + 3].Item2;
							you_set_us_up.Add(temp_str);
						}

					} else {
						Console.WriteLine("Error: missing keyword YOU SET US UP");
					}

				} 

				// Console.WriteLine(hey_christmas_tree.Count);
				// Console.WriteLine(you_set_us_up.Count);

				hey_christmas_tree.ForEach(str_val => Console.WriteLine(str_val));
				you_set_us_up.ForEach(str_val => Console.WriteLine(str_val));

				int h_expr_size = hey_christmas_tree.Count;
				int y_expr_size = you_set_us_up.Count;

				if ((h_expr_size == expression_size) && (y_expr_size == expression_size)) {
					program_expressions.Add(hey_christmas_tree);
					program_expressions.Add(you_set_us_up);
					Console.WriteLine("Added to program expressions");
					hey_christmas_tree.Clear();
					you_set_us_up.Clear();
					h_expr_size = 0;
					y_expr_size = 0;
				}

			}
			
		}   

		// prioritize this!
    	public void talk_to_the_hand(Dictionary<int, Tuple<string, string>> lexeme_collection) {

    	}

    	// prioritize this!
    	public void arithmetic_ops(Dictionary<int, Tuple<string, string>> lexeme_collection) {
			
			List<string> arithmetic_expr = new List<string>();
			int math_expr_size = 2;				// Count() is a LINQ extension method, usage explained in readme.txt

			foreach (KeyValuePair<int, Tuple<string, string>> lexeme in lexeme_collection) {
				if (lexeme.Value.Item2 == "GET UP") {
					Console.WriteLine("am here!!");
					arithmetic_expr.Add(lexeme.Value.Item2);
				} else if (lexeme.Value.Item2 == "GET DOWN") {
					arithmetic_expr.Add(lexeme.Value.Item2);
				} else if (lexeme.Value.Item2 == "YOU'RE FIRED") { 
					arithmetic_expr.Add(lexeme.Value.Item2);
				} else if (lexeme.Value.Item2 == "HE HAD TO SPLIT") {
					arithmetic_expr.Add(lexeme.Value.Item2);
				} else if (lexeme.Value.Item2 == "Integer literal") {
					Console.WriteLine("now am here!!");
					arithmetic_expr.Add(lexeme.Value.Item2);
				}

				Console.WriteLine(math_expr_size);
				Console.WriteLine(arithmetic_expr.Count);

				if (arithmetic_expr.Count == math_expr_size) {
					string math_expr = string.Join(" ", arithmetic_expr.ToArray());
					Console.WriteLine(math_expr);
					break;
				}

			}


			if (arithmetic_expr.Contains("GET UP") && arithmetic_expr.Contains("Integer literal")) {
				Console.WriteLine("Add method valid.");
			} else if (arithmetic_expr.Contains("GET DOWN") && arithmetic_expr.Contains("Integer literal")) {
				Console.WriteLine("Subtract method valid.");
			} else if (arithmetic_expr.Contains("YOU'RE FIRED") && arithmetic_expr.Contains("Integer literal")) {
				Console.WriteLine("Multiply method valid.");
			} else if (arithmetic_expr.Contains("HE HAD TO SPLIT") && arithmetic_expr.Contains("Integer literal")) {
				Console.WriteLine("Divide method valid.");
			}

			// I'm supposed to add this knowledge to the symbol table but I'm not entirely sure what I'm supposed to put there.

		}    	

		public void logical_ops(Dictionary<int, Tuple<string, string>> lexeme_collection) {
			
		}   	  	

		public void reassign_variable(Dictionary<int, Tuple<string, string>> lexeme_collection) {
			
		}    	

		public void if_else(Dictionary<int, Tuple<string, string>> lexeme_collection) {
			
		}    	

		public void while_loop(Dictionary<int, Tuple<string, string>> lexeme_collection) {
			
		} 

		// try to implement a function that will automatically do all of the above. 

		// public void parse_file(Dictionary<int, Tuple<string, string>> lexeme_collection) {
		// 	this.main_method(lexeme_collection);
		// }    	

    }
}
