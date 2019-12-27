require_relative 'expression_machine'
require_relative 'statement_machine'

class Machine
  def self.new(syntax, *args)
    machine_class =
      case syntax
      when Add, Boolean, LessThan, Multiply, Number, Variable
        ExpressionMachine
      when Assign, DoNothing, If, Sequence, While
        StatementMachine
      else
        raise "Unrecognized syntax: #{syntax.inspect}"
      end

    machine_class.new(syntax, *args)
  end
end